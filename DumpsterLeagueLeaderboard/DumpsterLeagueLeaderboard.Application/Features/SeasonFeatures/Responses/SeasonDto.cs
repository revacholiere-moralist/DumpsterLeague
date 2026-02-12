using static System.Runtime.InteropServices.JavaScript.JSType;
namespace DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Responses;
public class SeasonDto : CommonResponseDto
{
    public Guid LeagueEventId { get; set; }
    public string LeagueEventName { get; set; } = string.Empty;
    public string SeasonName { get; set; } = string.Empty;
    public bool IsCurrent { get; set; } = false;
    public DateTime SeasonStartDate { get; set; } = new DateTime();
    public DateTime SeasonEndDate { get; set; } = new DateTime();
}