namespace SistemaVenta.Model
{
    public class Producto
    {
    
        public int Id { get; set; }
        public string Nombre { get; set; } = String.Empty;
        public string Descripcion { get; set; } = String.Empty;
        
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; } = null!;
       
        public double PrecioCompra { get; set; } = 0;
        public double PrecioVenta { get; set; } = 0;

        public int CantidadDisponible { get; set; } = 0;

       
        
        public void ActualizarCantidad(int nuevaCantidad)
        {
            CantidadDisponible = nuevaCantidad;
        }

        public void ActualizarPrecio(double nuevoPrecio)
        {
            PrecioVenta = nuevoPrecio;
        }

    }
}
