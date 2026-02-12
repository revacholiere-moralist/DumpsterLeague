using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class PointQueryRepository : BaseQueryRepository<Point>, IPointQueryRepository
    {
        public PointQueryRepository(
            ApplicationReadContext context) : base(context)
        {
        }
    }
}
