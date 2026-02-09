using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class PlayerPlacementHistoryEntityTypeConfiguration : BasicEntityTypeConfiguration<PlayerPlacementHistory>, IEntityTypeConfiguration<PlayerPlacementHistory>
    {
        public override void Configure(EntityTypeBuilder<PlayerPlacementHistory> builder)
        {
            base.Configure(builder);
            
            builder.Property(p => p.PlayerId)
                .HasColumnName("player_id")
                .IsRequired();
            
            builder.HasOne(p => p.Player)
                .WithMany(p => p.PlacementHistories)
                .HasForeignKey(p => p.PlayerId);
            
            builder.Property(p => p.TournamentId)
                .HasColumnName("tournament_id")
                .IsRequired();
            
            builder.HasOne(p => p.Tournament)
                .WithMany()
                .HasForeignKey(p => p.TournamentId);
            
            builder.Property(p => p.IsCurrent)
                .HasColumnName("is_current")
                .IsRequired();
            
            builder.Property(p => p.CurrentPoints)
                .HasColumnName("current_points")    
                .IsRequired();
            
            builder.Property(p => p.PointsGained)
                .HasColumnName("points_gained")
                .IsRequired();
                
            builder.Property(p => p.Placement)
                .HasColumnName("placement")
                .IsRequired();
        }
    }
}
