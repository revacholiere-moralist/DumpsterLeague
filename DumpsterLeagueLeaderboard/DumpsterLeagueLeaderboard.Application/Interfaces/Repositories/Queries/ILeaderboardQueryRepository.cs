
using DumpsterLeagueLeaderboard.Domain.Entities;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries
{
    public interface ILeaderboardQueryRepository : IQueryRepository<Leaderboard>
    {
        Task<List<Leaderboard>> GetCurrentLeaderboard(Guid eventId, Guid seasonId, CancellationToken cancellationToken = default);
    }
}

