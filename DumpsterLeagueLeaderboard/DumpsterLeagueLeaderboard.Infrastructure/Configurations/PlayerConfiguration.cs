using DumpsterLeagueLeaderboard.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class PlayerEntityTypeConfiguration : BasicEntityTypeConfiguration<Player>, IEntityTypeConfiguration<Player>
    {
        public void Configure(EntityTypeBuilder<Player> builder)
        {

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
