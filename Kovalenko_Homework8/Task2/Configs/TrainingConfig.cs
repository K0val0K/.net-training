using Task2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task2.Configs
{
    public class TrainingConfig : IEntityTypeConfiguration<Training>
    {
        public void Configure(EntityTypeBuilder<Training> entity)
        {
            entity.ToTable(nameof(Training));
            entity.HasKey(x => x.Id);
            entity.Property(p => p.TrainingName).IsRequired().HasMaxLength(64);
            entity.Property(p => p.StartDate).IsRequired().HasColumnType("date");
            entity.Property(p => p.EndDate).IsRequired().HasColumnType("date");
            entity.Property(p => p.Description);

        }
    }
}
