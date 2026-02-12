using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class SeasonQueryRepository : BaseQueryRepository<Season>, ISeasonQueryRepository
    {
        public SeasonQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }

        public async Task<List<Season>> GetSeasonsByLeagueEvent(Guid leagueId, CancellationToken cancellationToken = default)
        {
            return await _readContext.Seasons.Where(s => s.LeagueEventId == leagueId).ToListAsync(cancellationToken);
        }
    }
}
