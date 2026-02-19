using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands
{
    public class PlayerPlacementHistoryRepository : BaseCommandRepository<PlayerPlacementHistory>, IPlayerPlacementHistoryRepository
    {
        public PlayerPlacementHistoryRepository(
            ApplicationWriteContext context) : base(context)
        {
        }
    }
}
