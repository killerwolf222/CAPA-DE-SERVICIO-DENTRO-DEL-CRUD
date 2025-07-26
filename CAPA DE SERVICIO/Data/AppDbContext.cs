using Microsoft.EntityFrameworkCore;
using MICRUDGABRIEL.Models;

namespace MICRUDGABRIEL.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Producto> Productos { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Trainer> Trainers { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Precio).HasColumnType("decimal(18,2)");
            });


            modelBuilder.Entity<Member>().ToTable("Miembros");
            modelBuilder.Entity<Trainer>().ToTable("Entrenadores");
        }
    }
}




