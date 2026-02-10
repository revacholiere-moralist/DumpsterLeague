namespace DumpsterLeagueLeaderboard.Application.Features.PlayersFeatures.Responses;
public class BasicPlayerDto
{
    public int PlayerId { get; set; }
    public string CurrentDiscordId { get; set; } = "";

    public string CurrentDiscordName { get; set; } = "";

    public string CurrentIgn { get; set; } = "";

    public int CurrentPoints { get; set; } = 0;
}