namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
public class UpdateLeagueEventRequest
{
    public Guid LeagueEventId { get; set; }
    public string EventName { get; set; } = "";

    public bool IsOngoing {get; set;  } = true;

}