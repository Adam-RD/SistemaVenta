using SistemaVenta.DTOs;

namespace SistemaVenta.Interfaces
{
    public interface ICategoria
    {
        Task<IEnumerable<CategoriaDTO>> ObtenerTodasLasCategorias();
        Task<CategoriaDTO> ObtenerCategoriaPorId(int id);
        Task AgregarCategoria(CategoriaDTO categoriaDto);
        Task ActualizarCategoria(CategoriaDTO categoriaDto);
        Task EliminarCategoria(int id);
    }

}
