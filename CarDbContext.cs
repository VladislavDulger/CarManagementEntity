using Microsoft.EntityFrameworkCore;

namespace CarManagementEntity
{
    internal class CarDbContext : DbContext
    {
        public DbSet <Car> Cars { get; set;}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=4514;Database=CarsDb");
        }
    }
}
