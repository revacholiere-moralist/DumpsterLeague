using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class TournamentQueryRepository : BaseQueryRepository<Tournament>, ITournamentQueryRepository
    {
        public TournamentQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }

        
        public async Task<List<Tournament>> GetTournamentsByLeagueEvent(Guid leagueEventId, CancellationToken cancellationToken = default)
        {
            return await _readContext.Tournaments.Where(t => t.LeagueEventId == leagueEventId && t.IsActive).ToListAsync(cancellationToken);
        }

        public async Task<List<Tournament>> GetTournamentsByLeagueEventAndSeason(Guid leagueEventId, Guid seasonId, CancellationToken cancellationToken = default)
        {
            return await _readContext.Tournaments.Where(t => t.LeagueEventId == leagueEventId && t.SeasonId == seasonId && t.IsActive).ToListAsync(cancellationToken);
        }

        public async Task<List<Tournament>> GetTournamentsByLeagueEventAndSeason2(Guid leagueEventId, Guid seasonId, CancellationToken cancellationToken = default)
        {
            return await _readContext.Tournaments.Where(t => t.LeagueEventId == leagueEventId && t.SeasonId == seasonId && t.IsActive).ToListAsync(cancellationToken);
        }
    }
}
