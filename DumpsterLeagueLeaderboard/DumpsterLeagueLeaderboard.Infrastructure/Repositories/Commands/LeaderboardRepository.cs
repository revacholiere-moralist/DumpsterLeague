using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands
{
    public class LeaderboardRepository : BaseCommandRepository<Leaderboard>, ILeaderboardRepository
    {
        public LeaderboardRepository(
            ApplicationWriteContext context) : base(context)
        {
        }
    }
}
