using Microsoft.EntityFrameworkCore;
using System;

namespace API_Project_BenjaminGamrekeli.Entities
{
    public class DierContext:DbContext
    {
        public DbSet<Dier> Dieren { get; set; }
        public DbSet<Habitat> Habitats { get; set; }
        public DbSet<Klasse> Klassen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server = localhost; port = 3306; database = dieren-db; user=root;";
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DierHabitat>()
                .HasKey(pa => new { pa.DierId, pa.HabitatId });
            base.OnModelCreating(modelBuilder);
        }
    }
}
