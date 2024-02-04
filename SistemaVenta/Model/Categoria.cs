namespace SistemaVenta.Model
{
    public class Categoria
    {
        public int Id { get; set; }

        public string NombreCategoria { get; set; } = string.Empty;

        public HashSet<Producto> Productos { get; set; } = new HashSet<Producto>();


    }
}
