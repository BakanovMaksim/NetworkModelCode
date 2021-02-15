using Microsoft.EntityFrameworkCore;

using NetworkModelCode.Core.Domain.Entities;

namespace NetworkModelCode.Infrastructure.Data
{
    public class NetworkModelContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }

        public DbSet<TechnologicalCondition> TechnologicalConditions { get; set; }

        public DbSet<TimeCharacteristic> TimeCharacteristics { get; set; }

        public NetworkModelContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=NetworkModel;Trusted_Connection=True;");
        }
    }
}
