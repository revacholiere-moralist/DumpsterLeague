using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class Season : Common.BaseEntity
    {

        [Column("season_name")]
        public string SeasonName { get; set; } = "";
        [Column("season_start_date")]
        public DateTime SeasonStartDate { get; set; } = DateTime.UtcNow;
        [Column("season_end_date")]
        public DateTime SeasonEndDate { get; set; } = DateTime.UtcNow;
        [Column("is_current")]
        public bool IsCurrent { get; set; } = true;
        
    }
}
