using DumpsterLeagueLeaderboard.Domain.Common;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands
{
    public interface ICommandRepository<T> where T : BaseEntity
    {
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
