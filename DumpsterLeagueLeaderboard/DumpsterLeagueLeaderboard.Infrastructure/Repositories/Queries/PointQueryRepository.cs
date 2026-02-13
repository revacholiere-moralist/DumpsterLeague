using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class PointQueryRepository : BaseQueryRepository<Point>, IPointQueryRepository
    {
        public PointQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }

        public async Task<List<Point>> GetPointsByEventAndSeasonAsync(Guid leagueEventId, Guid seasonId, CancellationToken cancellationToken)
        {
            return await _readContext.Points.Where(p => p.LeagueEventId == leagueEventId && p.SeasonId == seasonId && p.IsActive).ToListAsync(cancellationToken);
        }
    }
}
