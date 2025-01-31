using Scalar.AspNetCore;
using App.Domain.AppServices.Hw20.Car;
using App.Domain.AppServices.Hw20.CarModel;
using App.Domain.AppServices.Hw20.Company;
using App.Domain.AppServices.Hw20.Log;
using App.Domain.AppServices.Hw20.Request;
using App.Domain.AppServices.Hw20.User;
using App.Domain.Core.Hw20.Car.AppService;
using App.Domain.Core.Hw20.Car.Data;
using App.Domain.Core.Hw20.Car.Service;
using App.Domain.Core.Hw20.CarModel.AppService;
using App.Domain.Core.Hw20.CarModel.Data;
using App.Domain.Core.Hw20.CarModel.Service;
using App.Domain.Core.Hw20.Company.AppService;
using App.Domain.Core.Hw20.Company.Data;
using App.Domain.Core.Hw20.Company.Service;
using App.Domain.Core.Hw20.Log.AppService;
using App.Domain.Core.Hw20.Log.Data;
using App.Domain.Core.Hw20.Log.Service;
using App.Domain.Core.Hw20.Request.AppService;
using App.Domain.Core.Hw20.Request.Data;
using App.Domain.Core.Hw20.Request.Service;
using App.Domain.Core.Hw20.User.AppService;
using App.Domain.Core.Hw20.User.Data;
using App.Domain.Core.Hw20.User.Service;
using App.Domain.Services.Hw20.Car;
using App.Domain.Services.Hw20.CarModel;
using App.Domain.Services.Hw20.Company;
using App.Domain.Services.Hw20.Log;
using App.Domain.Services.Hw20.Request;
using App.Domain.Services.Hw20.User;
using App.Infra.Data.Db.SqlServer.Ef.DbContext;
using App.Infra.Data.Repos.Ef.Hw20.Car;
using App.Infra.Data.Repos.Ef.Hw20.CarModel;
using App.Infra.Data.Repos.Ef.Hw20.Company;
using App.Infra.Data.Repos.Ef.Hw20.Log;
using App.Infra.Data.Repos.Ef.Hw20.Request;
using App.Infra.Data.Repos.Ef.Hw20.User;
using Microsoft.EntityFrameworkCore;
using App.Domain.Core.Hw20.Config;
using Hw20.Endpoints.Api.Middleware;
using App.Domain.Core.Hw20.User.Entities;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();


var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var siteSettings = configuration.GetSection("SiteSettings").Get<SiteSettings>();
builder.Services.AddSingleton(siteSettings);



builder.Services.AddScoped<ICarModelService, CarModelService>();
builder.Services.AddScoped<ICarModelAppService, CarModelAppService>();
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<IRequestAppService, RequestAppService>();
builder.Services.AddScoped<IRequestRepository, RequestRepository>();
builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<ILogAppService, LogAppService>();
builder.Services.AddScoped<ICarAppService, CarAppService>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ICarService, CarService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserAppService, UserAppService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyAppService, CompanyAppService>();

builder.Services.AddIdentity<User, IdentityRole<int>>()
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>();







builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(siteSettings.ConnectionStrings.SqlConnection));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseApiKeyValidation();
app.UseHttpsRedirection();



app.UseAuthorization();

app.MapControllers();

app.Run();
