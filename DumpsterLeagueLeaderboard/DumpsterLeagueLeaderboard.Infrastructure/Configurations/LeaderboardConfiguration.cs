using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class LeaderboardEventEntityTypeConfiguration : BasicEntityTypeConfiguration<Leaderboard>, IEntityTypeConfiguration<Leaderboard>
    {
        public override void Configure(EntityTypeBuilder<Leaderboard> builder)
        {
            base.Configure(builder);
            
            builder.Property(p => p.LeagueEventId)
                .HasColumnName("league_event_id")
                .IsRequired();
                
            builder.HasOne<LeagueEvent>(p => p.LeagueEvent)
                .WithMany(p => p.Leaderboards)
                .HasForeignKey(p => p.LeagueEventId);
            
            builder.Property(p => p.SeasonId)
                .HasColumnName("season_id")
                .IsRequired();
                
            builder.HasOne<Season>(p => p.Season)
                .WithMany(p => p.Leaderboards)
                .HasForeignKey(p => p.SeasonId);
                
            builder.Property(p => p.PlayerId)
                .HasColumnName("player_id")
                .IsRequired();
            
            builder.HasOne<Player>(p => p.Player)
                .WithMany()
                .HasForeignKey(p => p.PlayerId);
            
            builder.Property(p => p.TournamentId)
                .HasColumnName("tournament_id")
                .IsRequired();
            
            builder.HasOne<Tournament>(p => p.Tournament)
                .WithMany()
                .HasForeignKey(p => p.TournamentId);
            
            builder.Property(p => p.CurrentPoints)
                .HasColumnName("current_points")
                .IsRequired();
                
            builder.Property(p => p.PointsGained)
                .HasColumnName("points_gained")
                .IsRequired();
                
            builder.Property(p => p.Placement)
                .HasColumnName("placement")
                .IsRequired();
            
            builder.Property(p => p.LeaderboardDate)
                .HasColumnName("leaderboard_date")
                .IsRequired();
            
            builder.Property(p => p.IsDisqualified)
                .HasColumnName("is_disqualified")
                .IsRequired(); 
            
            builder.Property(p => p.IsCurrent)
                .HasColumnName("is_current")
                .IsRequired();
            
            
        }
    }
}
