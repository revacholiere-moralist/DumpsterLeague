using static System.Net.Mime.MediaTypeNames;
namespace DumpsterLeagueLeaderboard.Application.Features.SeasonFeatures.Requests;
public class AddSeasonRequest
{
    public string SeasonName { get; set; } = "";

    public DateTime SeasonStartDate {get; set;  } = DateTime.Now;
    public DateTime SeasonEndDate {get; set;  } = DateTime.Now;
    public bool IsCurrent { get; set; } = true;
    public Guid LeagueEventId { get; set; } = Guid.NewGuid();

}