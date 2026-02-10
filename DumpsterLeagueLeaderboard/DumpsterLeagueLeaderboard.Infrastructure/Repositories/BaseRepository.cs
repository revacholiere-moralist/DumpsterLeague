using DumpsterLeagueLeaderboard.Domain.Common;
using DumpsterLeagueLeaderboard.Application.Interfaces.Repositories;
using DumpsterLeagueLeaderboard.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    protected readonly ApplicationWriteContext _writeContext;
    protected readonly ApplicationReadContext  _readContext;

    public BaseRepository(
        ApplicationWriteContext writeContext,
        ApplicationReadContext readContext)
    {
        _writeContext = writeContext;
        _readContext = readContext;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _readContext.Set<T>().ToListAsync(cancellationToken);
    }
    public virtual async Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await _readContext.Set<T>().FindAsync(id, cancellationToken);
        return result ?? new T();
    }
    public virtual async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        var result = await _writeContext.Set<T>().AddAsync(entity, cancellationToken);
        return result.Entity;
    }
    public virtual void Update(T entity)
    {
        _writeContext.Set<T>().Update(entity);
    }
    
    public virtual void Delete(T entity)
    {
        _writeContext.Set<T>().Remove(entity);
    }
}