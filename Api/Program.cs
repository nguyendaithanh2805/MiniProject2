using Application.Commands;
using Application.Commands.Handlers;
using Application.DTOs;
using Abstractions.Interfaces;
using Application.Queries;
using Application.Queries.Handlers;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application;
using Mapster;
using MapsterMapper;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Repo
builder.Services.AddScoped<IRepository<Menu>, MenuRepository>();
builder.Services.AddScoped<IRepository<News>, NewsRepository>();

// Đăng ký MediatR(tự động quét toàn bộ handlers)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AssemblyMarker).Assembly));

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
