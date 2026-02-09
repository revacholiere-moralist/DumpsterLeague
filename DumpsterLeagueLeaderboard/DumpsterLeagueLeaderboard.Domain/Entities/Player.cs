using System.ComponentModel.DataAnnotations.Schema;

namespace DumpsterLeagueLeaderboard.Domain.Entities
{
    public class Player : Common.BaseEntity
    {
        [Column("current_discord_id")]
        public string CurrentDiscordId { get; set; } = "";
        [Column("current_discord_name")]
        public string CurrentDiscordName { get; set; } = "";
        [Column("current_ign")]
        public string CurrentIgn { get; set; } = "";
        [Column("current_points")]
        public int CurrentPoints { get; set; } = 0;
        
    }
}
