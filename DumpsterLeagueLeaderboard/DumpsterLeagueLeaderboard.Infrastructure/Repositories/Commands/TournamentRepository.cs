using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands
{
    public class TournamentRepository : BaseCommandRepository<Tournament>, ITournamentRepository
    {
        public TournamentRepository(
            ApplicationWriteContext context) : base(context)
        {
        }
    }
}
