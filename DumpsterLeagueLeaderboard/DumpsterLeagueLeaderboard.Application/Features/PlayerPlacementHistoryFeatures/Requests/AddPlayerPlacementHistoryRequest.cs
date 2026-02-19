namespace DumpsterLeagueLeaderboard.Application.Features.PlayerPlacementHistoryFeatures.Requests;
public class PlayerPlacementHistoryPlayerRequest
{
    public Guid PlayerId { get; set; } = Guid.NewGuid();
    public int Placement { get; set; } = -1;
    public bool IsCurrent { get; set; } = true;
    public bool IsDisqualified { get; set; } = false;
}

public class AddPlayerPlacementHistoryRequest
{
    public Guid TournamentId { get; set; } = Guid.NewGuid();

    public List<PlayerPlacementHistoryPlayerRequest> Players { get; set; } = null!;
}