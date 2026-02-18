namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Requests;
public class AddTournamentRequest
{
    public string TournamentName { get; set; } = "";

    public DateTime TournamentDate {get; set;  } = DateTime.Now;
    public string StartGgLink { get; set; } = "";
    public Guid? LeagueEventId { get; set; } = null;
    public Guid? SeasonId { get; set; } = null;

}