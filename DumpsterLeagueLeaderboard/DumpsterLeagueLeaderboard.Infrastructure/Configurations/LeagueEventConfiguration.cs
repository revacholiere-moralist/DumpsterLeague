using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class LeagueEventEntityTypeConfiguration : BasicEntityTypeConfiguration<LeagueEvent>, IEntityTypeConfiguration<LeagueEvent>
    {
        public override void Configure(EntityTypeBuilder<LeagueEvent> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.EventName)
                .HasColumnName("event_name")
                .IsRequired();
            
            builder.Property(p => p.IsOngoing)
                .HasColumnName("is_ongoing")
                .IsRequired();
            
            builder.HasMany(p => p.Seasons)
                .WithOne(p => p.LeagueEvent)
                .HasForeignKey(p => p.LeagueEventId);
            
            builder.HasMany(p => p.Tournaments)
                .WithOne(p => p.LeagueEvent)
                .HasForeignKey(p => p.LeagueEventId);
        }
    }
}
