using AgenciadeViajesJF.Application.Features.Shared.Mapping;
using AgenciadeViajesJF.Infrastructure.Data.Context;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using AgenciadeViajesJF.Application.Features.GestionReservas.Interfaces;
using AgenciadeViajesJF.Application.Features.GestionReservas;
using AgenciadeViajesJF.Application.Features.GestionHoteles.Interfaces;
using AgenciadeViajesJF.Application.Features.GestionHoteles;
using AgenciadeViajesJF.Domain.Hoteles.Interfaces;
using AgenciadeViajesJF.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la base de datos
builder.Services.AddDbContext<AgenciaViajesContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Configuración de AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

// Registro de servicios
builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IReservaRepository, ReservaRepository>();
builder.Services.AddScoped<IHabitacionRepository, HabitacionRepository>();
builder.Services.AddScoped<IGestionReservasUseCase, GestionReservasUseCase>();
builder.Services.AddScoped<IGestionHotelUseCase, GestionHotelUseCase>();

builder.Services.AddControllers();

// Configuración de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.MapControllers();
app.Run();
