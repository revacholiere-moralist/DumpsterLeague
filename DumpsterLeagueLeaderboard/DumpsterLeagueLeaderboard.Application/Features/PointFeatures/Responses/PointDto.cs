namespace DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Responses;
public class PointDto : CommonResponseDto
{
    public Guid LeagueEventId { get; set; } = Guid.Empty;

    public Guid SeasonId { get; set; } = Guid.Empty;

    public int Position { get; set; } = 0;

    public int PointGained { get; set; } = 0;
}