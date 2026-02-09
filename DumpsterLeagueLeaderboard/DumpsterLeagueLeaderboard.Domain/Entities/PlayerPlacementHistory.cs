using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class PlayerPlacementHistory : Common.BaseEntity
    {
        [Column("player_placement_history_id")]
        public override Guid Id { get; set; }
        
        [Column("player_id")]
        public Guid PlayerId { get; set; } = Guid.NewGuid();
        public Player Player { get; set; } = null!;
        [Column("tournament_id")]
        public Guid TournamentId { get; set; } = Guid.NewGuid();
        public Tournament Tournament { get; set; } = null!;
        [Column("placement")]
        public int Placement { get; set; } = -1;    
        [Column("current_points")]
        public int CurrentPoints { get; set; } = 0;
        [Column("points_gained")]
        public int PointsGained { get; set; } = 0;
        [Column("is_current")]
        public bool IsCurrent { get; set; } = true;
    }
}
