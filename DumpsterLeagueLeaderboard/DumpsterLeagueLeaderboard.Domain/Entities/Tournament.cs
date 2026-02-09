using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class Tournament : Common.BaseEntity
    {
        [Column("league_event_id")]
        public Guid? LeagueEventId { get; set; }
        public LeagueEvent? LeagueEvent { get; set; }
        [Column("season_id")]
        public Guid? SeasonId { get; set; } = null;
        public virtual Season? Season { get; set; } = null;
        [Column("tournament_name")]
        public string TournamentName { get; set; } = "";
        [Column("tournament_date")]
        public DateTime TournamentDate { get; set; } = DateTime.UtcNow;
        [Column("start_gg_link")]
        public string StartGgLink { get; set; } = "";
    }
}
