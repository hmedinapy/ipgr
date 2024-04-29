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
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<IAnalisisRiesgoRepository, AnalisisRiesgoRepository>();
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
  options.UseSqlServer(builder.Configuration.GetConnectionString("DbTest3Context")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
