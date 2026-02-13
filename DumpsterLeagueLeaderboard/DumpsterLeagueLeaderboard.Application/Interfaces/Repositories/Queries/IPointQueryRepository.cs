
using DumpsterLeagueLeaderboard.Domain.Entities;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries
{
    public interface IPointQueryRepository : IQueryRepository<Point>
    {
        Task<List<Point>> GetPointsByEventAndSeasonAsync(Guid leagueEventId, Guid seasonId, CancellationToken cancellationToken);
    }
}

