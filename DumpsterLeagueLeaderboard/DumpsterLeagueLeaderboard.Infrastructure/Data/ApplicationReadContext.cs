using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Data
{
    public class ApplicationReadContext : ApplicationDbContext
    {
        public ApplicationReadContext(DbContextOptions<ApplicationReadContext> options) : base(options) { }
    }
}