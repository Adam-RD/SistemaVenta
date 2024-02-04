using AutoMapper;
using SistemaVenta.DTOs;
using SistemaVenta.Interfaces;
using SistemaVenta.Model;
using Microsoft.EntityFrameworkCore;


namespace SistemaVenta.Repository
{
    public class CategoriaRepository : ICategoria
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        public CategoriaRepository(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategoriaDTO> ObtenerCategoriaPorId(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            return _mapper.Map<CategoriaDTO>(categoria);
        }

        public async Task<IEnumerable<CategoriaDTO>> ObtenerTodasLasCategorias()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return _mapper.Map<IEnumerable<CategoriaDTO>>(categorias);
        }

        public async Task AgregarCategoria(CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarCategoria(CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);
            _context.Categorias.Update(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }
    }

}
