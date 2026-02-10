using DumpsterLeagueLeaderboard.Infrastructure;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using DumpsterLeagueLeaderboard.Application;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//TODO: Add logging
builder.Services.ConfigureCommandContext(builder.Configuration.GetConnectionString("DumpsterLeagueCommandDb")!);
builder.Services.ConfigureQueryContext(builder.Configuration.GetConnectionString("DumpsterLeagueQueryDb")!);

builder.Services.ConfigureRepository();
builder.Services.ConfigureApplication();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
