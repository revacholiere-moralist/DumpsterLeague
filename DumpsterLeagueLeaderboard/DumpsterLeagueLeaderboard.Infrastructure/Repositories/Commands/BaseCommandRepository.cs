using DumpsterLeagueLeaderboard.Domain.Common;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using DumpsterLeagueLeaderboard.Application.Exceptions;

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
            try
            {
                var result = await _writeContext!.Set<T>().AddAsync(entity, cancellationToken);
                return result.Entity;
            }
            catch (Exception ex)
            {
                throw new EntityException(string.Format("Exception occured when adding an object of {0} type: {1}", entity.GetType(), ex.Message));
            }

        }
        public virtual async Task Update(T entity)
        {
            try
            {
                _writeContext!.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw new EntityException(string.Format("Exception occured when updating an object of {0} type: {1}", entity.GetType(), ex.Message));             
            }
        }
        
        public virtual async Task Delete(T entity)
        {
            try
            {
                _writeContext!.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new EntityException(string.Format("Exception occured when deleting an object of {0} type: {1}", entity.GetType(), ex.Message));             
            }
        }
    }
}

