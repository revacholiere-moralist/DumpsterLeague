using DumpsterLeagueLeaderboard.Application.Common.Responses;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;

namespace DumpsterLeagueLeaderboard.Application.Features.LeaderboardFeatures.Responses;
public class LeaderboardDto : CommonResponseDto
{
    public Guid PlayerId { get; set; } = Guid.NewGuid();
    public PlayerDto Player { get; set; } = null!;
    public Guid TournamentId { get; set; } = Guid.NewGuid();
    public TournamentDto Tournament { get; set; } = null!;
    public Guid LeagueEventId { get; set; } = Guid.NewGuid();
    public Guid SeasonId { get; set; } = Guid.NewGuid();
    public bool IsDisqualified { get; set; } = false;
    public int Position { get; set; } = -1;    
    public int CurrentPoints { get; set; } = 0;
    public int PointsGained { get; set; } = 0;
    public int PreviousPoints { get; set; }
    public bool IsCurrent { get; set; } = true;
}