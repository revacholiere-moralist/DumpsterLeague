using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class LeagueEventQueryRepository : BaseQueryRepository<LeagueEvent>, ILeagueEventQueryRepository
    {
        public LeagueEventQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }
    }
}
