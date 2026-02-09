using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class Point : Common.BaseEntity
    {
        [Column("position")]
        public int Position { get; set; } = 0;
        [Column("point_gained")]
        public int PointGained { get; set; } = 0;
        
    }
}
