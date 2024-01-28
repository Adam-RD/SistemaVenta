using Microsoft.EntityFrameworkCore;
//using SistemaVenta.Interfaces;

namespace SistemaVenta.Model
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options) { }

        public DbSet<Reparacion> Reparaciones{ get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Otras configuraciones de servicios

            services.AddScoped<IReparacionRepository, ReparacionRepository>();

            // ...
        }


        
    }
}
