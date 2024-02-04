using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaVenta.DTOs;
using SistemaVenta.Interfaces;
using SistemaVenta.Model;

namespace SistemaVenta.Repository
{
    public class ProductoRepository : IProducto
    {
        private readonly AplicationDbContext _context;
        private readonly IMapper _mapper;

        public ProductoRepository(AplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProductoDTO> ObtenerProductoPorId(int id)
        {
            var producto = await _context.Productos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
            return _mapper.Map<ProductoDTO>(producto);
        }

        public async Task<IEnumerable<ProductoDTO>> ObtenerTodosLosProductos()
        {
            var productos = await _context.Productos.Include(p => p.Categoria).ToListAsync();
            return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
        }

        public async Task<IEnumerable<ProductoDTO>> BuscarProductoPorNombre(string nombre)
        {
            var productos = await _context.Productos
                .Include(p => p.Categoria)
                .Where(p => p.Nombre.Contains(nombre))
                .ToListAsync();

            return _mapper.Map<IEnumerable<ProductoDTO>>(productos);
        }


        public async Task AgregarProducto(ProductoDTO productoDto)
        {
            var producto = _mapper.Map<Producto>(productoDto);
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task ActualizarProducto(ProductoDTO productoDto)
        {
            var productoExistente = await _context.Productos.FindAsync(productoDto.Id);
            if (productoExistente == null)
            {
                throw new Exception($"Producto con ID {productoDto.Id} no encontrado.");
            }
            _mapper.Map(productoDto, productoExistente);
            await _context.SaveChangesAsync();
        }

        public async Task EliminarProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                throw new Exception($"Producto con ID {id} no encontrado.");
            }
            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }
    }

}
