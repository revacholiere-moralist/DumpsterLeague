using Microsoft.EntityFrameworkCore;
namespace DumpsterLeagueLeaderboard.Infrastructure.Data
{
    public class ApplicationWriteContext : ApplicationDbContext
    {
        public ApplicationWriteContext(DbContextOptions<ApplicationWriteContext> options) : base(options) { }
    }
}