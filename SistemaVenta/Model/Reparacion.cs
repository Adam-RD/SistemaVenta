using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaVenta.Model

{
    public class Reparacion
    {
        public int Id { get; set; }
        public string Descricion { get; set; }= string.Empty;
        public double Inversion { get; set; } = 0;
        public double ManoObra { get; set; } = 0;
        
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public double Total { get; set; } = 0;
        public string NombreCliente { get; set; } =string.Empty;

        public double Descento { get; set; } = 0;

        public Reparacion()
        {
            Fecha = DateTime.Now;
            CalcularTotal();
        }

        public void CalcularTotal()
        {
            Total = (Inversion + ManoObra) - ((Inversion +ManoObra)*(Descento/100));
        }
    }
}
