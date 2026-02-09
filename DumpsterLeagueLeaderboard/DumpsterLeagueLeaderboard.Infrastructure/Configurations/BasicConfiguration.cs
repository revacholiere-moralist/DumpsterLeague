using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class BasicEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Domain.Common.BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder
                .ToTable(typeof(T).Name.ToLower() + "s");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName(typeof(T).Name.ToLower() + "_id")
                .IsRequired();

            builder.Property(p => p.IsActive)
                .HasColumnName("is_active")
                .IsRequired();
            
            builder.Property(p => p.CreatedAt)
                .HasColumnName("created_at")
                .IsRequired();
            
            builder.Property(p => p.UpdatedAt)
                .HasColumnName("updated_at")
                .IsRequired();
        }
    }
}
