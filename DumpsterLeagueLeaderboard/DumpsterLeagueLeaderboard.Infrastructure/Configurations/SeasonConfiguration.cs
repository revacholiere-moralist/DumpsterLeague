using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class SeasonEntityTypeConfiguration : BasicEntityTypeConfiguration<Season>, IEntityTypeConfiguration<Season>
    {
        public void Configure(EntityTypeBuilder<Season> builder)
        {
            builder.Property(p => p.Id)
                .HasColumnName("season_id")
                .IsRequired();

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
