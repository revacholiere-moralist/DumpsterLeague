namespace DumpsterLeagueLeaderboard.Application.Features.PointFeatures.Requests;

public class AddPointRequest
{
        public Guid LeagueEventId { get; set; } = Guid.Empty;
        public Guid SeasonId { get; set; } = Guid.Empty;
        public int Position { get; set; } = 0;
        public int PointGained { get; set; } = 0;
}
