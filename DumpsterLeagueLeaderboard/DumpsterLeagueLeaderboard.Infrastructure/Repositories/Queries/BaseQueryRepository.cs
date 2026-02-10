using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Common;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class BaseQueryRepository<T> : IQueryRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationReadContext  _readContext;

        public BaseQueryRepository(
            ApplicationReadContext readContext)
        {
            _readContext = readContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _readContext!.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual async Task<T>? GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return await _readContext!.Set<T>().FindAsync(id, cancellationToken);
            #pragma warning restore CS8603 // Possible null reference return.
        }
    }
}
