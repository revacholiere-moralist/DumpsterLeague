
using DumpsterLeagueLeaderboard.Domain.Entities;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries
{
    public interface ITournamentQueryRepository : IQueryRepository<Tournament>
    {
        public Task<List<Tournament>> GetTournamentsByLeagueEvent(Guid leagueEventId, CancellationToken cancellationToken = default);
        public Task<List<Tournament>> GetTournamentsByLeagueEventAndSeason(Guid leagueEventId, Guid seasonId, CancellationToken cancellationToken = default);
    }
}

