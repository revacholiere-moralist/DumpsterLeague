using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;

namespace DumpsterLeagueLeaderboard.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Player> Players { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
