using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands
{
    public class LeagueEventRepository : BaseCommandRepository<LeagueEvent>, ILeagueEventRepository
    {
        public LeagueEventRepository(
            ApplicationWriteContext context) : base(context)
        {
        }
    }
}
