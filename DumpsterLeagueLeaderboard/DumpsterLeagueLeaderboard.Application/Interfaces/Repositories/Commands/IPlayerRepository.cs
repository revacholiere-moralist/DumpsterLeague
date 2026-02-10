using DumpsterLeagueLeaderboard.Domain.Entities;

namespace DumpsterLeagueLeaderboard.Application.Interfaces.Repositories.Commands
{
    public interface IPlayerRepository : ICommandRepository<Player>
    {
    }

}