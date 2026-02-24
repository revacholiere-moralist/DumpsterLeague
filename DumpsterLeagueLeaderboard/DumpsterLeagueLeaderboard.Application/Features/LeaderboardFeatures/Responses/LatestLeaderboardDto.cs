using DumpsterLeagueLeaderboard.Application.Common.Responses;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;

namespace DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Responses;
public class LatestLeaderboardDto : CommonResponseDto
{
    public int Position { get; set; } = -1;   
    public string PlayerIGN { get; set; } = string.Empty;
    public string LeagueEventName { get; set; } = string.Empty;
    public string SeasonName { get; set; } = string.Empty;
    public DateTime SeasonStart { get; set; } = DateTime.MinValue;
    public DateTime SeasonEnd { get; set; } = DateTime.MinValue;
    public string LastTournamentName { get; set; } = string.Empty;
    public DateTime LastTournamentDate { get; set; } = DateTime.MinValue;
    public bool IsDisqualified { get; set; } = false;
 
    public int CurrentPoints { get; set; } = 0;
    public int PointsGained { get; set; } = 0;
    public int PreviousPoints { get; set; } = 0;
}