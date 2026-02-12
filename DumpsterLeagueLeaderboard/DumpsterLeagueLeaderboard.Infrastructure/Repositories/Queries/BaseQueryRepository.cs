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

        public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _readContext!.Set<T>().ToListAsync(cancellationToken);
        }

        public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _readContext!.Set<T>().FindAsync(id, cancellationToken);
            if (result is null)
            {
                return new T();
            }
            return result;
        }
    }
}
