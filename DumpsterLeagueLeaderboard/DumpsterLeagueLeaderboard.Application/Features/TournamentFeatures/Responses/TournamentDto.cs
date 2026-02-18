using DumpsterLeagueLeaderboard.Application.Common.Responses;

namespace DumpsterLeagueLeaderboard.Application.Features.TournamentFeatures.Responses;
public class TournamentDto : CommonResponseDto
{
    public Guid TournamentId { get; set; }
    public Guid? LeagueEventId { get; set; } = null;
    public string? LeagueEventName { get; set; } = null;
    public Guid? SeasonId { get; set; } = null;
    public string? SeasonName { get; set; } = null; 
    public string TournamentName { get; set; } = string.Empty;
    public DateTime TournamentDate { get; set; }
    public string StartGgLink { get; set; }
}