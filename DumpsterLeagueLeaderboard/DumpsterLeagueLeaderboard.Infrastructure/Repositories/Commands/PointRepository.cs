using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Domain.Entities;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands
{
    public class PointRepository : BaseCommandRepository<Point>, IPointRepository
    {
        public PointRepository(
            ApplicationWriteContext context) : base(context)
        {
        }
    }
}
