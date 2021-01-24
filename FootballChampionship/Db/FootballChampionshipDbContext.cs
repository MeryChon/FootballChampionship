using FootballChampionship.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FootballChampionship.Db
{
    public class FootballChampionshipDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.;database=footballchampionships;Integrated security=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
