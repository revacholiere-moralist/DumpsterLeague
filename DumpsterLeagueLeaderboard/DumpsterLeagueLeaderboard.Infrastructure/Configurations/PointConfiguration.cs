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

            builder.Property(p => p.Position)
                .HasColumnName("position")
                .IsRequired();

            builder.Property(p => p.PointGained)
                .HasColumnName("point_gained")
                .IsRequired();
        }
    }
}
