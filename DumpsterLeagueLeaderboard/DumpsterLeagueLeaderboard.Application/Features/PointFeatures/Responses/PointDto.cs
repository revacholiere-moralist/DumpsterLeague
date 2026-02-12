namespace DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Responses;
public class PointDto : CommonResponseDto
{
    public string CurrentDiscordId { get; set; } = "";

    public string CurrentDiscordName { get; set; } = "";

    public string CurrentIgn { get; set; } = "";

    public int CurrentPoints { get; set; } = 0;
}