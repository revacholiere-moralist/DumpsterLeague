
using DumpsterLeagueLeaderboard.Domain.Entities;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries
{
    public interface ISeasonQueryRepository : IQueryRepository<Season>
    {
        public Task<List<Season>> GetSeasonsByLeagueEvent(Guid leagueEventId, CancellationToken cancellationToken = default);
    }
}

