using Microsoft.AspNetCore.Mvc;
using SistemaVenta.DTOs;
using SistemaVenta.Interfaces;

namespace SistemaVenta.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _productoRepository;

        public ProductoController(IProducto productoRepository)
        {
            _productoRepository = productoRepository;
        }


        [HttpGet]
        public async Task<IActionResult> ObtenerTodosLosProductos()
        {
            var productos = await _productoRepository.ObtenerTodosLosProductos();
            return Ok(productos);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerProductoPorId(int id)
        {
            var producto = await _productoRepository.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> AgregarProducto([FromBody] ProductoDTO productoDto)
        {
            await _productoRepository.AgregarProducto(productoDto);
            return CreatedAtAction(nameof(ObtenerProductoPorId), new { id = productoDto.Id }, productoDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, [FromBody] ProductoDTO productoDto)
        {
            if (id != productoDto.Id)
            {
                return BadRequest();
            }
            await _productoRepository.ActualizarProducto(productoDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarProducto(int id)
        {
            await _productoRepository.EliminarProducto(id);
            return NoContent();
        }
    }
}
