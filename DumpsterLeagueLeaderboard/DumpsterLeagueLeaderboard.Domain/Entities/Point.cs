using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class Point : Common.BaseEntity
    {
        [Column("league_event_id")]
        public Guid LeagueEventId { get; set; }
        public LeagueEvent LeagueEvent { get; set; } = null!;

        [Column("season_id")]
        public Guid SeasonId { get; set; }
        public Season Season { get; set; } = null!;

        [Column("position")]
        public int Position { get; set; } = 0;
        [Column("point_gained")]
        public int PointGained { get; set; } = 0;
        
    }
}
