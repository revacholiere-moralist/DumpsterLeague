using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class PlayerQueryRepository : BaseQueryRepository<Player>, IPlayerQueryRepository
    {
        public PlayerQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }
    }
}
