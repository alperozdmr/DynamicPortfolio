using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Concrete;
using Portfolio.DataAccess.Context;
using Portfolio.Entity.concrete;
using Portfolio.Service.Abstract;
using Portfolio.Service.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);


var requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
    .Build();

//builder.Services.AddDbContext<PortfolioContext>();
builder.Services.AddHttpClient();
// builder.Services.AddDbContext<PortfolioContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<PortfolioContext>(options =>
{
    var connStr = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(connStr, sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(5),
            errorNumbersToAdd: null
        );
    });
});

builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<PortfolioContext>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());


builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAboutDal, EfAboutDal>();

builder.Services.AddScoped<IProjectService, ProjectManager>();
builder.Services.AddScoped<IProjectDal, EfProjectDal>();

builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IContactDal, EfContactDal>();

builder.Services.AddScoped<IEducationService, EducationManager>();
builder.Services.AddScoped<IEducationDal, EfEducationDal>();

builder.Services.AddScoped<IExperienceService, ExperienceManager>();
builder.Services.AddScoped<IExperienceDal, EfExperienceDal>();

builder.Services.AddScoped<IProjectDetailService, ProjectDetailManager>();
builder.Services.AddScoped<IProjectDetailDal, EfProjectDetailDal>();

builder.Services.AddScoped<IImageListService, ImageListManager>();
builder.Services.AddScoped<IImageListDal, EfImageListDal>();

// Add services to the container.
//builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews(opt =>
    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy))
);
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Login/Index";
});
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var db = services.GetRequiredService<PortfolioContext>();

    // SQL container geç açılabiliyor -> retry
    var retries = 20;
    for (var i = 1; i <= retries; i++)
    {
        try
        {
            await db.Database.MigrateAsync();
            break;
        }
        catch (Exception ex)
        {
            if (i == retries) throw;
            Console.WriteLine($"[DB MIGRATE] Attempt {i}/{retries} failed: {ex.Message}");
            await Task.Delay(TimeSpan.FromSeconds(3));
        }
    }

    // Seed ayarları (koda password gömmek yok)
    var seedEnabled = builder.Configuration.GetValue<bool>("Seed:Enabled");
    if (seedEnabled)
    {
        var roleManager = services.GetRequiredService<RoleManager<AppRole>>();
        var userManager = services.GetRequiredService<UserManager<AppUser>>();

        var adminRole = builder.Configuration["Seed:AdminRole"] ?? "Admin";
        var adminEmail = builder.Configuration["Seed:AdminEmail"];
        var adminUserName = builder.Configuration["Seed:AdminUserName"] ?? adminEmail;
        var adminPassword = builder.Configuration["Seed:AdminPassword"];

        if (string.IsNullOrWhiteSpace(adminEmail) || string.IsNullOrWhiteSpace(adminPassword))
        {
            Console.WriteLine("[SEED] AdminEmail/AdminPassword boş. Seed atlandı.");
        }
        else
        {
            // 1) Rol yoksa oluştur
            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                var roleCreate = await roleManager.CreateAsync(new AppRole { Name = adminRole });
                if (!roleCreate.Succeeded)
                    throw new Exception("Admin role oluşturulamadı: " + string.Join(", ", roleCreate.Errors.Select(e => e.Description)));
            }

            // 2) Kullanıcı yoksa oluştur
            var existingUser = await userManager.FindByEmailAsync(adminEmail);
            if (existingUser == null)
            {
                var newUser = new AppUser
                {
                    UserName = adminUserName,
                    Email = adminEmail,
                    EmailConfirmed = true
                };

                var userCreate = await userManager.CreateAsync(newUser, adminPassword);
                if (!userCreate.Succeeded)
                    throw new Exception("Admin user oluşturulamadı: " + string.Join(", ", userCreate.Errors.Select(e => e.Description)));

                existingUser = newUser;
            }

            // 3) Role ata (değilse)
            if (!await userManager.IsInRoleAsync(existingUser, adminRole))
            {
                var addToRole = await userManager.AddToRoleAsync(existingUser, adminRole);
                if (!addToRole.Succeeded)
                    throw new Exception("Admin role ataması başarısız: " + string.Join(", ", addToRole.Errors.Select(e => e.Description)));
            }

            Console.WriteLine($"[SEED] Admin hazır: {adminEmail} (Role: {adminRole})");
        }
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UILayout}/{action=Index}/{id?}");

app.Run();
