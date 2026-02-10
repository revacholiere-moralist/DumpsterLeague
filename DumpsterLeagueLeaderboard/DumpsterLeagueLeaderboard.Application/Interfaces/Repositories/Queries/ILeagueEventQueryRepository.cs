
using DumpsterLeagueLeaderboard.Domain.Entities;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries
{
    public interface ILeagueEventQueryRepository : IQueryRepository<LeagueEvent>
    {
        public Task<List<LeagueEvent>> GetActiveLeagueEventsAsync(CancellationToken cancellationToken = default);
    }
}

