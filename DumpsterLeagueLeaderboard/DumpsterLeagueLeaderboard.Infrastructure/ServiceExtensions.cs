using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands;
using DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DumpsterLeagueLeaderboard.Infrastructure;
public static class ServiceExtensions
{
    public static void ConfigureCommandContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationWriteContext>(
            options => options.UseNpgsql(connectionString));
    }

    public static void ConfigureQueryContext(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationReadContext>(
            options => options.UseNpgsql(connectionString));
    }

    public static void ConfigureRepository(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ILeagueEventRepository, LeagueEventRepository>();
        services.AddScoped<ILeagueEventQueryRepository, LeagueEventQueryRepository>();
        
        services.AddScoped<ISeasonRepository, SeasonRepository>();
        services.AddScoped<ISeasonQueryRepository, SeasonQueryRepository>();
        
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<IPlayerQueryRepository, PlayerQueryRepository>();
        
        services.AddScoped<IPointRepository, PointRepository>();
        services.AddScoped<IPointQueryRepository, PointQueryRepository>();

        services.AddScoped<ITournamentRepository, TournamentRepository>();
        services.AddScoped<ITournamentQueryRepository, TournamentQueryRepository>();
    }
}