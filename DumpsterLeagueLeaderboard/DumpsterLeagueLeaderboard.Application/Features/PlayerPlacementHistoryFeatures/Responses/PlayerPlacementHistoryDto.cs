using DumpsterLeagueLeaderboard.Application.Common.Responses;
using DumpsterLeagueLeaderboard.Application.Features.PlayerFeatures.Responses;
using DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;

namespace DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Responses;
public class PlayerPlacementHistoryDto : CommonResponseDto
{
    public Guid PlayerId { get; set; } = Guid.NewGuid();
    public PlayerDto Player { get; set; } = null!;
    public Guid TournamentId { get; set; } = Guid.NewGuid();
    public TournamentDto Tournament { get; set; } = null!;
    public int Placement { get; set; } = -1;    
    public int CurrentPoints { get; set; } = 0;
    public int PointsGained { get; set; } = 0;
    public bool IsCurrent { get; set; } = true;
}