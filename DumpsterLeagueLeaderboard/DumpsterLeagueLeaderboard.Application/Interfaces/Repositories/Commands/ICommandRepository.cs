using DumpsterLeagueLeaderboard.Domain.Common;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands
{
    public interface ICommandRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        void Update(T entity);
        void Delete(T entity);
    }
}
