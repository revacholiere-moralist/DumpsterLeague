using System.Reflection.Metadata.Ecma335;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries;
using DumpsterLeagueLeaderboard.Domain.Common;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Queries
{
    public class BaseQueryRepository<T> : IQueryRepository<T> where T : BaseEntity, new()
    {
        protected readonly ApplicationReadContext  _readContext;

        public BaseQueryRepository(
            ApplicationReadContext readContext)
        {
            _readContext = readContext;
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(bool getActiveOnly = true, CancellationToken cancellationToken = default)
        {
            var query = await _readContext!.Set<T>().ToListAsync(cancellationToken);
            if (getActiveOnly)
            {
                query = query.Where(e => e.IsActive).ToList();
            }
            return query;
        }

        public virtual async Task<T> GetByIdAsync(Guid id, bool getActiveOnly = true, CancellationToken cancellationToken = default)
        {
            var result = await _readContext!.Set<T>().FindAsync(id, cancellationToken);
            if (result is null)
            {
                return new T();
            }
            if (getActiveOnly && !result.IsActive)
            {
                return new T();
            }
            return result;
        }
    }
}
