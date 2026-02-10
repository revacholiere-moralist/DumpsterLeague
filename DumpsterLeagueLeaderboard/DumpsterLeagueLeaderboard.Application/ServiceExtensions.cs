using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace DumpsterLeagueLeaderboard.Application;

public static class ServiceExtensions
{
    public static void ConfigureApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
    }

}