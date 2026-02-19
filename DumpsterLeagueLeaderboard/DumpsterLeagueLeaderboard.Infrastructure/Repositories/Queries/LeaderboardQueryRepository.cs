using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class LeaderboardQueryRepository : BaseQueryRepository<Leaderboard>, ILeaderboardQueryRepository
    {
        public LeaderboardQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }

        public async Task<List<Leaderboard>> GetCurrentLeaderboard(Guid eventId, Guid seasonId, CancellationToken cancellationToken = default)
        {
            return await _readContext.Leaderboards.Where(l => l.LeagueEventId == eventId
                                                        && l.SeasonId == seasonId
                                                        && l.IsCurrent
                                                        && l.IsActive)
                                                    .ToListAsync(cancellationToken);
        }
    }
}
