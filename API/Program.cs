using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using PruebaTecnica.Core.Application.Features.Activities.Queries;
using PruebaTecnica.Core.Application.Features.Goals.Commands;
using PruebaTecnica.Core.Infrestructure;
using PruebaTecnica.Core.Persistence;
using System.Reflection;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CoreDbContext>(options =>
           options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var assembly = typeof(ListActivitiesQuerys).Assembly;

InfrastructureServiceCollectionExtensions.AddInfrastructureServices(builder.Services, assembly);
builder.Services.AddAutoMapper(assembly);
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
            .AllowAnyOrigin()
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

app.Use(async (ctx, next) =>
{
	try
	{
		await next();
	}
	catch (HttpRequestException ex)
	{
		ctx.Response.StatusCode = 200;
		await ctx.Response.WriteAsJsonAsync(ex.Message);
	}
});

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
