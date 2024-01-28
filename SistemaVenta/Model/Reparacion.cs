using Swashbuckle.AspNetCore.Annotations;

namespace SistemaVenta.Model

{
    public class Reparacion
    {
        public int Id { get; set; }
        public string? Descricion { get; set; }
        public double Inversion { get; set; }
        public double ManoObra { get; set; }
        public DateTime Fecha { get; set; }
        public double Total { get; set; }
        public string? NombreCliente { get; set; }

        public Reparacion()
        {
            Fecha = DateTime.Now;
            CalcularTotal();
        }

        private void CalcularTotal()
        {
            Total = Inversion + ManoObra;
        }
    }
}
