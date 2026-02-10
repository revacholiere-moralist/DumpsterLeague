using DumpsterLeagueLeaderboard.Application.Repositories;
using DumpsterLeagueLeaderboard.Infrastructure.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationWriteContext _context;

    public UnitOfWork(ApplicationWriteContext context)
    {
        _context = context;
    }

    public async Task Save(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}