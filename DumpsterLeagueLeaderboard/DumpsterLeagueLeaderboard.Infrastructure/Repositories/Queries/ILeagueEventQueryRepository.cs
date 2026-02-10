using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class LeagueEventQueryRepository : BaseQueryRepository<LeagueEvent>, ILeagueEventQueryRepository
    {
        public LeagueEventQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }

        public async Task<List<LeagueEvent>> GetActiveLeagueEventsAsync(CancellationToken cancellationToken = default)
        {
            return await _readContext.LeagueEvents.Where(le => le.IsActive).ToListAsync(cancellationToken);
        }
    }
}
