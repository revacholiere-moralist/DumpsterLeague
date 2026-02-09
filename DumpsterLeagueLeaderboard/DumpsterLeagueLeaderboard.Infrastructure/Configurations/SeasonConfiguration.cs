using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class SeasonEntityTypeConfiguration : BasicEntityTypeConfiguration<Season>, IEntityTypeConfiguration<Season>
    {
        public override void Configure(EntityTypeBuilder<Season> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.LeagueEventId)
                .HasColumnName("league_event_id");
                
            builder.HasOne(p => p.LeagueEvent)
                .WithMany(p => p.Seasons)
                .HasForeignKey(p => p.LeagueEventId);
                
            builder.Property(p => p.SeasonName)
                .HasColumnName("season_name")
                .IsRequired();

            builder.Property(p => p.SeasonStartDate)
                .HasColumnName("season_start_date")
                .IsRequired();

            builder.Property(p => p.SeasonEndDate)
                .HasColumnName("season_end_date")
                .IsRequired();

            builder.Property(p => p.IsCurrent)
                .HasColumnName("is_current")
                .IsRequired();
        }
    }
}
