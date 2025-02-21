using Portfolio.DataAccess.Abstract;
using Portfolio.DataAccess.Concrete;
using Portfolio.DataAccess.Context;
using Portfolio.Service.Abstract;
using Portfolio.Service.Concrete;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((Host) => true)
        .AllowCredentials();
    });
});

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
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
