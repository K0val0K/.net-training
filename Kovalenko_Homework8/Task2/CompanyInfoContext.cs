using Microsoft.EntityFrameworkCore;
using Task2.Entities;
using Task2.Configs;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Task2
{
    public class CompanyInfoContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; } 
        public DbSet<Training> Training { get; set; }
        public DbSet<Vacation> Vacation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new TrainingConfig());
            modelBuilder.ApplyConfiguration(new VacationConfig());

        }
    }
}
