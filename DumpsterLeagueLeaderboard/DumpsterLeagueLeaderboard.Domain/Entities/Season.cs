using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class Season : Common.BaseEntity
    {
        [Column("league_event_id")]
        public Guid LeagueEventId { get; set; } = Guid.NewGuid();
        public LeagueEvent LeagueEvent { get; set; } = null!;
        [Column("season_name")]
        public string SeasonName { get; set; } = "";
        [Column("season_start_date")]
        public DateTime SeasonStartDate { get; set; } = DateTime.UtcNow;
        [Column("season_end_date")]
        public DateTime SeasonEndDate { get; set; } = DateTime.UtcNow;
        [Column("is_current")]
        public bool IsCurrent { get; set; } = true;
        public List<Leaderboard> Leaderboards { get; set; } = new List<Leaderboard>();
        public List<Tournament> Tournaments { get; set; } = new List<Tournament>(); 
        
    }
}
