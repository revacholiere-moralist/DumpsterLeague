
using DumpsterLeagueLeaderboard.Domain.Entities;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries
{
    public interface IPlayerPlacementHistoryQueryRepository : IQueryRepository<PlayerPlacementHistory>
    {
        Task<List<PlayerPlacementHistory>> GetByEventAndSeason(Guid eventId, Guid seasonId, Guid playerId, CancellationToken cancellationToken = default);
        Task<List<PlayerPlacementHistory>> GetCurrentByEventAndSeason(Guid eventId, Guid seasonId, CancellationToken cancellationToken = default);
    }
}

