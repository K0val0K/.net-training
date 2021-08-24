using Task2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task2.Configs
{
    public class VacationConfig : IEntityTypeConfiguration<Vacation>
    {
        public void Configure(EntityTypeBuilder<Vacation> entity)
        {
            entity.ToTable(nameof(Vacation));
            entity.HasKey(x => x.Id);
            entity.Property(p => p.StartDate).IsRequired().HasColumnType("date");
            entity.Property(p => p.EndDate).IsRequired().HasColumnType("date");

            entity.HasOne(p => p.Employee).WithMany(v => v.Vacations);

        }
    }
}
