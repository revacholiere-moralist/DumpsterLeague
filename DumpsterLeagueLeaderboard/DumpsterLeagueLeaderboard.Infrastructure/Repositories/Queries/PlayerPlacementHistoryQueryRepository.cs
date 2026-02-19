using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class PlayerPlacementHistoryQueryRepository : BaseQueryRepository<PlayerPlacementHistory>, IPlayerPlacementHistoryQueryRepository
    {
        public PlayerPlacementHistoryQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }

        public async Task<List<PlayerPlacementHistory>> GetByEventAndSeason(Guid eventId, Guid seasonId, Guid playerId, CancellationToken cancellationToken = default)
        {
            return await _readContext.PlayerPlacementHistories.Where(p => p.Tournament.LeagueEventId == eventId
                                                                    && p.Tournament.SeasonId == seasonId
                                                                    && p.PlayerId == playerId
                                                                    && p.IsActive)
                                                                .Include(p => p.Tournament).ToListAsync(cancellationToken);
        }

        public async Task<List<PlayerPlacementHistory>> GetCurrentByEventAndSeason(Guid eventId, Guid seasonId, CancellationToken cancellationToken = default)
        {
            return await _readContext.PlayerPlacementHistories.Where(p => p.Tournament.LeagueEventId == eventId
                                                                    && p.Tournament.SeasonId == seasonId
                                                                    && p.IsCurrent
                                                                    && p.IsActive)
                                                                .Include(p => p.Tournament).ToListAsync(cancellationToken);
        }
    }
}
