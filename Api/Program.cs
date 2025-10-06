using Abstraction.Commands;
using Abstractions.Queries;
using Application.Commands.Menus;
using Application.Commands.Menus.Handlers;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Application.Queries.Menus;
using Application.Queries.Menus.Handlers;
using Domain.Entities;
using Infrastructure.Dispatchers;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<Menu>, MenuRepository>();

builder.Services.AddScoped<ICommandHandler<AddMenuCommand>, AddMenuCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateMenuCommand>, UpdateMenuCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveMenuCommand>, RemoveMenuCommandHandler>();

builder.Services.AddScoped<ICommandDispatcher, CommanDispatcher>();
builder.Services.AddAutoMapper(cfg => { }, typeof(MapperProfile).Assembly);

builder.Services.AddScoped<IQueryHandler<GetAllMenusQuery, IEnumerable<MenuDto>>, GetAllMenusQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetMenuByIdQuery, MenuDto>, GetMenuByIdHandler>();
builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

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
