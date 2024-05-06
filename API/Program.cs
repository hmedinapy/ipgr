using API.Extensions;
using API.Models;
using API.Reposirory;
using API.Reposirory.AnalisisRiesgos;
using API.Reposirory.Areas;
using API.Reposirory.Departamentos;
using API.Reposirory.Empresas;
using API.Reposirory.PlanesTrabajos;
using API.Reposirory.PlanesTrabajosPuntos;
using API.Reposirory.Riesgos;
using API.Reposirory.Roles;
using API.Services;
using Microsoft.DotNet.Scaffolding.Shared.CodeModifier.CodeChange;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
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

builder.Services.AddScoped<IAuthManager, AuthManager>();
builder.Services.AddScoped<IDbDataSet<AnalisisRiesgo>, AnalisisRiesgoRepository>();
builder.Services.AddScoped<IDbDataSet<Area>, AreaRepository>();
builder.Services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
builder.Services.AddScoped<IEmpresaRepository, EmpresaRepository>();
builder.Services.AddScoped<IPlanTrabajoRepository, PlanTrabajoRepository>();
builder.Services.AddScoped<IPlanTrabajoPuntoRepository, PlanTrabajoPuntoRepository>();
builder.Services.AddScoped<IRiesgoRepository, RiesgoRepository>();
builder.Services.AddScoped<IRolRepository, RolRepository>();

builder.Services.AddControllersWithViews()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<DbTest3Context>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DbTest5Context")));

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity(Configuration: configuration);

// TODO remove SetEnvironmentVariable
Environment.SetEnvironmentVariable("KEY", "this is my custom Secret key for authentication");
builder.Services.ConfigureJWT(Configuration: configuration);

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
}

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
