using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Concrete;
using Portfolio.DataAccess.Context;
using Portfolio.Service.Abstract;
using Portfolio.Service.Concrete;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddDbContext<PortfolioContext>();
builder.Services.AddHttpClient();
builder.Services.AddScoped<PortfolioContext>();
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

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=UILayout}/{action=Index}/{id?}");

app.Run();
