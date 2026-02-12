namespace DumpsterLeagueLeaderboard.Application.Features.LeagueEventFeatures.Responses;
public class LeagueEventDto : CommonResponseDto
{

    public string EventName { get; set; } = "";

    public bool IsOngoing {get; set;  } = true;

}