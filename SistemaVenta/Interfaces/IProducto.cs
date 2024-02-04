using SistemaVenta.DTOs;

namespace SistemaVenta.Interfaces
{
    public interface IProducto
    {
        Task<ProductoDTO> ObtenerProductoPorId(int id);
        Task<IEnumerable<ProductoDTO>> ObtenerTodosLosProductos();
        Task AgregarProducto(ProductoDTO productoDto);
        Task ActualizarProducto(ProductoDTO productoDto);
        Task EliminarProducto(int id);
    }

}
