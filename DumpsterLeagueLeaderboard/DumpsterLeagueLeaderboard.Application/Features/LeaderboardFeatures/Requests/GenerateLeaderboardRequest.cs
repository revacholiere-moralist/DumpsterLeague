using System.ComponentModel.DataAnnotations.Schema;
namespace DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Requests;

public class GenerateLeaderboardRequest
{
    public Guid LeagueEventId { get; set; }
    public Guid SeasonId { get; set; }
}
