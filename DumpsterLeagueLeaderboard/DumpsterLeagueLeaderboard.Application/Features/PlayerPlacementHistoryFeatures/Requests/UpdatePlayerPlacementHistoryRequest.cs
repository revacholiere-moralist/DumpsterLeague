namespace DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Requests;

public class UpdatePlayerPlacementHistoryRequest
{
    public Guid PlayerPlacementHistoryId { get; set; } = Guid.NewGuid();
    public Guid TournamentId { get; set; } = Guid.NewGuid();
    public Guid PlayerId { get; set; } = Guid.NewGuid();
    public int Placement { get; set; } = -1;
    public bool IsCurrent { get; set; } = true;
    public bool IsDisqualified { get; set; } = false;
}