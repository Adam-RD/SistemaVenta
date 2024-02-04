using Microsoft.EntityFrameworkCore;
using SistemaVenta.Interfaces;
using SistemaVenta.Repository;
//using SistemaVenta.Interfaces;

namespace SistemaVenta.Model
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reparacion>().Property(a => a.Fecha).HasColumnType("date");
        }

        public DbSet<Reparacion> Reparaciones{ get; set; }

        public DbSet<Producto> Productos { get; set; }

        public DbSet <Categoria> Categorias { get; set; } 

        

              
    }
}
