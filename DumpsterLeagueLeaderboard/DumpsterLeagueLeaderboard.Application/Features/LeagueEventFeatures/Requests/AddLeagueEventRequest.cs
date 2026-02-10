namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Requests;
public class AddLeagueEventRequest
{
    public string EventName { get; set; } = "";

    public bool IsOngoing {get; set;  } = true;

}