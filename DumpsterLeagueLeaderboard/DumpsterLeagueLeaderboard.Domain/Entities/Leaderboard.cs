using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class Leaderboard : Common.BaseEntity
    {
        [Column("tournament_id")]
        public Guid TournamentId { get; set; }
        public Tournament Tournament { get; set; } = null;
        
        [Column("league_event_id")]
        public Guid LeagueEventId { get; set; }
        public LeagueEvent LeagueEvent { get; set; } = null;
        
        [Column("season_id")]
        public Guid SeasonId { get; set; }
        public Season Season { get; set; } = null!;
        
        [Column("player_id")]
        public Guid PlayerId { get; set; }
        public Player Player { get; set; } = null;
        
        [Column("current_points")]
        public int CurrentPoints { get; set; }
        
        [Column("points_gained")]
        public int PointsGained { get; set; }
        
        [Column("placement")]
        public int Placement { get; set; }
        
        [Column("leaderboard_date")]
        public DateTime LeaderboardDate { get; set; }
       
        [Column("is_disqualified")]
        public bool IsDisqualified { get; set; }
        
        [Column("is_current")]
        public bool IsCurrent { get; set; }
        
    }
}
