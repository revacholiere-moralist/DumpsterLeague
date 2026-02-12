using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands
{
    public class SeasonRepository : BaseCommandRepository<Season>, ISeasonRepository
    {
        public SeasonRepository(
            ApplicationWriteContext context) : base(context)
        {
        }
    }
}
