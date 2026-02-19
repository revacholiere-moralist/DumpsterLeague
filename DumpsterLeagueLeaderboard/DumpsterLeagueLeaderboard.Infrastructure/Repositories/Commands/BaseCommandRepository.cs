using DumpsterLeagueLeaderboard.Domain.Common;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

namespace DumpsterLeagueLeaderboard.Infrastructure.Repositories.Commands
{
    public class BaseCommandRepository<T> : ICommandRepository<T> where T : BaseEntity
    {
        protected readonly ApplicationWriteContext _writeContext;

        public BaseCommandRepository(
            ApplicationWriteContext writeContext)
        {
            _writeContext = writeContext;
        }

        public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            var result = await _writeContext!.Set<T>().AddAsync(entity, cancellationToken);
            return result.Entity;
        }
        public virtual async Task Update(T entity)
        {
            _writeContext!.Set<T>().Update(entity);
        }
        
        public virtual async Task Delete(T entity)
        {
            _writeContext!.Set<T>().Remove(entity);
        }
    }
}

