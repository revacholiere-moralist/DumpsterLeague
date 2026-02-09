using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace DumpsterLeagueLeaderboard.Domain.Common
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        [Column("created_at")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Column("updated_at")]
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [Column("is_active")]
        public bool IsActive { get; set; } = true;
    }
}
