using Task2.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Task2.Configs
{
    public class EmployeeConfig : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable(nameof(Employee));
            entity.HasKey(x => x.Id);
            entity.Property(p => p.Email).IsRequired().HasMaxLength(128); // add uniqie
            entity.Property(p => p.Name).IsRequired().HasMaxLength(128);
            entity.Property(p => p.Surname).IsRequired().HasMaxLength(128);

            entity.HasMany(x => x.Trainings)
                .WithMany(x => x.Employees)
                .UsingEntity<TrainingEmployee>(
                        right => right.HasOne<Training>().WithMany().HasForeignKey(x => x.TrainingId),
                        left => left.HasOne<Employee>().WithMany().HasForeignKey(x => x.EmployeeId),
                        join => join.ToTable("TrainingEmployee"));
            

        }
    }
}
