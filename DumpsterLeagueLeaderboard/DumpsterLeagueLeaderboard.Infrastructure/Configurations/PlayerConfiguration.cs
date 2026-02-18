using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using DumpsterLeagueLeaderboard.Domain.Entities;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class PlayerEntityTypeConfiguration : BasicEntityTypeConfiguration<Player>, IEntityTypeConfiguration<Player>
    {
        public override void Configure(EntityTypeBuilder<Player> builder)
        {
            base.Configure(builder);

            builder.Property(p => p.CurrentDiscordId)
                .HasColumnName("current_discord_id")
                .IsRequired();

            builder.Property(p => p.CurrentDiscordName)
                .HasColumnName("current_discord_name")
                .IsRequired();

            builder.Property(p => p.CurrentIgn)
                .HasColumnName("current_ign")
                .IsRequired();

            builder.Property(p => p.CurrentPoints)
                .HasColumnName("current_points")
                .IsRequired();

        }
    }
}
