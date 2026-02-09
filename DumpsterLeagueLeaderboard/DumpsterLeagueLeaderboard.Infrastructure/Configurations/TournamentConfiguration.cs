using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class TournamentEntityTypeConfiguration : BasicEntityTypeConfiguration<Tournament>, IEntityTypeConfiguration<Tournament>
    {
        public override void Configure(EntityTypeBuilder<Tournament> builder)
        {
            base.Configure(builder);
            
            builder.Property(p => p.LeagueEventId)
                .HasColumnName("league_event_id");
            
            builder.HasOne(p => p.LeagueEvent)
                .WithMany(p => p.Tournaments)
                .HasForeignKey(p => p.LeagueEventId);
                
            builder.Property(p => p.SeasonId)
                .HasColumnName("season_id");
            
            builder.HasOne(p => p.Season)
                .WithMany(p => p.Tournaments)
                .HasForeignKey(p => p.SeasonId);
            
            builder.Property(p => p.TournamentName)
                .HasColumnName("tournament_name")
                .IsRequired();

            builder.Property(p => p.TournamentDate)
                .HasColumnName("tournament_date")
                .IsRequired();

            builder.Property(p => p.StartGgLink)
                .HasColumnName("start_gg_link")
                .IsRequired();
        }
    }
}
