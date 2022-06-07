using FluentValidation.AspNetCore;
using System.Reflection;
using MatchDataManager.Api.Data;
using Microsoft.EntityFrameworkCore;
using AutoWrapper;
using MatchDataManager.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(options =>{
        // Automatic registration of validators in assembly
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITeamsRepository, TeamsRepository>();
builder.Services.AddScoped<ILocationRepository, LocationsRepository>();
builder.Services.AddScoped<IMatchContext, MatchContext>();

builder.Services.AddDbContext<MatchContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MatchDbContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseApiResponseAndExceptionWrapper(new AutoWrapperOptions { UseCustomSchema = true, IsDebug = true });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();