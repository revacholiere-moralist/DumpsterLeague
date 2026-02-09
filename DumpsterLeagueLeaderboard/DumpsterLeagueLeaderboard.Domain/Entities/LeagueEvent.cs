using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class LeagueEvent : Common.BaseEntity
    {
        [Column("league_event_id")]
        public override Guid Id { get; set; } = Guid.NewGuid();
        
        [Column("event_name")]
        public string EventName { get; set; } = "";
        [Column("is_ongoing")]
        public bool IsOngoing {get; set;  } = true;
        public List<Season> Seasons { get; set; } = new List<Season>();
        public List<Tournament> Tournaments { get; set; } = new List<Tournament>();
        public List<Leaderboard> Leaderboards { get; set; } = new List<Leaderboard>();
    }
}
