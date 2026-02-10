using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands
{
    public class PlayerRepository : BaseCommandRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(
            ApplicationWriteContext context) : base(context)
        {
        }
    }
}
