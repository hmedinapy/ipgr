using API.Core.Repository;
using API.Data.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwaggerDoc();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureAutoMapper();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<IAuthManager, AuthManager>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<DataBaseContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DbTest5Context")));

builder.Services.AddAuthorization();

builder.Services.AddIdentityApiEndpoints<ApiUser>()
    .AddEntityFrameworkStores<DataBaseContext>();

// TODO remove SetEnvironmentVariable
Environment.SetEnvironmentVariable("KEY", "this is my custom Secret key for authentication");

builder.Services.AddCors(o =>
{
    o.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.ConfigureExceptionHandler();
app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.MapControllers();
app.MapIdentityApi<ApiUser>();

app.Run();
