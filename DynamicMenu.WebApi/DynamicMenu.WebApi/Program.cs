using AutoMapper;
using DynamicMenu.Persistence;
using DynamicMenu.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using DynamicMenu.Application.Extension.DependencyExtension;
using DynamicMenu.WebApi.Middleware;
using DynamicMenu.Application.DynamicMenu.Commands.CreateMenu;
using DynamicMenu.Application.DynamicMenu.Queries.GetMenuList;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddSwaggerGen();

// DI Persistence
builder.Services.AddPersistance(builder.Configuration);

// DI Application
builder.Services.AddApplication(Assembly.GetExecutingAssembly());

builder.Services.AddCors(options => 
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();    
    });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using (var scope = app.Services.CreateAsyncScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DynamicMenuDbContext>();
    context.Database.EnsureCreated();
}

app.UseCustomExceptionHandler();
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

const string prefix = "/dynamicMenu-api/";

app.MapGet(prefix + "getMenu", async (Guid userId, Guid companyId, IMediator mediator) =>
{
    var mediatorQuery = new GetMenuListQuery
    {
        CompanyId = companyId,
        UserId = userId
    };

    var vm = await mediator.Send(mediatorQuery);
    return Results.Ok(vm);
});

app.MapPost(prefix + "createMenu", async ([FromBody] CreateMenuDto createMenuDto, IMediator mediator, IMapper mapper) =>
{
    var command = mapper.Map<CreateMenuCommand>(createMenuDto);
    var json = await mediator.Send(command);

    return Results.Ok(json);
});

app.UseHttpsRedirection();

app.Run();
