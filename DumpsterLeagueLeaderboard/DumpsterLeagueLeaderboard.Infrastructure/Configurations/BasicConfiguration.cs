using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DumpsterLeagueLeaderboard.Infrastructure.Configurations
{
    public class BasicEntityTypeConfiguration<T> : IEntityTypeConfiguration<T> where T : Domain.Common.BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            var tableName = typeof(T).Name;
            var capitalLetterIndexes = new List<int>();
            for (int i = 0; i < tableName.Length; i++)
            {
                if (char.IsUpper(tableName[i]))
                {
                    capitalLetterIndexes.Add(i);
                }
            }
            foreach (var index in capitalLetterIndexes.Skip(1))
            {
                tableName = tableName.Insert(index - 1 + capitalLetterIndexes.IndexOf(index), "_");
            }
            tableName = tableName.ToLower();
            
            if (tableName.EndsWith("y"))
            {
                builder
                    .ToTable(tableName.Substring(0, tableName.Length - 1) + "ies");
            }
            else if (tableName.EndsWith("s"))
            {
                builder
                    .ToTable(tableName + "es");
            }
            else
            {
                builder
                    .ToTable(tableName   + "s");
            }
            
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                .HasColumnName(tableName.ToLower() + "_id")
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
