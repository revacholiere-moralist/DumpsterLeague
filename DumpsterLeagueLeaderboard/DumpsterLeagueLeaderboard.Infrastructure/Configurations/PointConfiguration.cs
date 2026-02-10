using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class PointEntityTypeConfiguration : BasicEntityTypeConfiguration<Point>, IEntityTypeConfiguration<Point>
    {
        public override void Configure(EntityTypeBuilder<Point> builder)
        {
            base.Configure(builder);
            
            builder.Property(p => p.LeagueEventId)
                .HasColumnName("league_event_id")
                .IsRequired();

            builder.HasOne(p => p.LeagueEvent)
                .WithMany()
                .HasForeignKey(p => p.LeagueEventId);
            
            builder.Property(p => p.SeasonId)
                .HasColumnName("season_id")
                .IsRequired();

            builder.HasOne(p => p.Season)
                .WithMany()
                .HasForeignKey(p => p.SeasonId);    
                
            builder.Property(p => p.Position)
                .HasColumnName("position")
                .IsRequired();

            builder.Property(p => p.PointGained)
                .HasColumnName("point_gained")
                .IsRequired();
        }
    }
}
