using DumpsterLeagueLeaderboard.Domain.Common;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
    }
}
