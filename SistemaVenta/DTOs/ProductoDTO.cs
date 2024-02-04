namespace SistemaVenta.DTOs
{
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public double PrecioCompra { get; set; } = 0;
        public double PrecioVenta { get; set; } = 0;
        public int CantidadDisponible { get; set; } = 0;
    }


}
