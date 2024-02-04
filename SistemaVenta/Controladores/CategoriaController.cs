using Microsoft.AspNetCore.Mvc;
using SistemaVenta.DTOs;
using SistemaVenta.Interfaces;

namespace SistemaVenta.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _categoriaRepository;

        public CategoriaController(ICategoria categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerTodasLasCategorias()
        {
            var categorias = await _categoriaRepository.ObtenerTodasLasCategorias();
            return Ok(categorias);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerCategoriaPorId(int id)
        {
            var categoria = await _categoriaRepository.ObtenerCategoriaPorId(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return Ok(categoria);
        }

      
        [HttpPost]
        public async Task<IActionResult> AgregarCategoria([FromBody] CategoriaDTO categoriaDto)
        {
            await _categoriaRepository.AgregarCategoria(categoriaDto);
            return CreatedAtAction(nameof(ObtenerCategoriaPorId), new { id = categoriaDto.Id }, categoriaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCategoria(int id, [FromBody] CategoriaDTO categoriaDto)
        {
            if (id != categoriaDto.Id)
            {
                return BadRequest();
            }
            await _categoriaRepository.ActualizarCategoria(categoriaDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarCategoria(int id)
        {
            await _categoriaRepository.EliminarCategoria(id);
            return NoContent();
        }
    }

}
