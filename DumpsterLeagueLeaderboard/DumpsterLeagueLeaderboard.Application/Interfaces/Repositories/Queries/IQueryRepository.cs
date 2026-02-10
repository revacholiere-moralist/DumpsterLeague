using DumpsterLeagueLeaderboard.Domain.Common;
namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Queries
{
    public interface IQueryRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<T>? GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
