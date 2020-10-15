using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Security.Cryptography.X509Certificates;

namespace HalloWinForms.Data
{
    class EfContext : DbContext
    {
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Parkplatz> Parkplatz { get; set; }

        public EfContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Parkplatz2;Trusted_Connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auto>().HasMany<Person>(x => x.Besitzer);
            modelBuilder.Entity<Person>().HasMany<Auto>(x => x.Autos);
        }
    }
}
