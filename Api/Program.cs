using Abstraction.Commands;
using Abstractions.Queries;
using Application.Commands.Menus;
using Application.Commands.Menus.Handlers;
using Application.Commands.News;
using Application.Commands.News.Handlers;
using Application.DTOs;
using Application.Interfaces;
using Application.Mappings;
using Application.Queries.Menus;
using Application.Queries.Menus.Handlers;
using Application.Queries.News;
using Application.Queries.News.Handlers;
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

// Mapper
builder.Services.AddAutoMapper(cfg => { }, typeof(MapperProfile).Assembly);

// Repo
builder.Services.AddScoped<IRepository<Menu>, MenuRepository>();
builder.Services.AddScoped<IRepository<News>, NewsRepository>();

// Command
//// Menu
builder.Services.AddScoped<ICommandHandler<AddMenuCommand>, AddMenuCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateMenuCommand>, UpdateMenuCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveMenuCommand>, RemoveMenuCommandHandler>();

// New
builder.Services.AddScoped<ICommandHandler<AddNewCommand>, AddNewCommandHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateNewCommand>, UpdateNewCommandHandler>();
builder.Services.AddScoped<ICommandHandler<RemoveNewCommand>, RemoveNewCommandHandler>();

// Dispatcher
builder.Services.AddScoped<ICommandDispatcher, CommanDispatcher>();
builder.Services.AddScoped<IQueryDispatcher, QueryDispatcher>();

// Query
//// Menu
builder.Services.AddScoped<IQueryHandler<GetAllMenusQuery, IEnumerable<MenuDto>>, GetAllMenusQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetMenuByIdQuery, MenuDto>, GetMenuByIdHandler>();

//// New
builder.Services.AddScoped<IQueryHandler<GetAllNewsQuery, IEnumerable<NewsDto>>, GetAllNewsQueryHandler>();
builder.Services.AddScoped<IQueryHandler<GetNewByIdQuery, NewsDto>, GetNewByIdQueryHandler>();


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
