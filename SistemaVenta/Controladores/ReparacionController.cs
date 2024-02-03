using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaVenta.Model;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class ReparacionController : ControllerBase
{
    private readonly IReparacionRepository _reparacionRepository;
    private readonly IMapper _mapper;

    public ReparacionController(IReparacionRepository reparacionRepository, IMapper mapper)
    {
        _reparacionRepository = reparacionRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [SwaggerResponse(200, "Lista de reparaciones", typeof(IEnumerable<ReparacionDTO>))]
    public IEnumerable<ReparacionDTO> GetAllReparaciones()
    {
        var reparaciones = _reparacionRepository.GetAll();

        foreach (var reparacion in reparaciones)
        {
            // Calcular el Total para cada reparación
            reparacion.CalcularTotal();
        }

        return _mapper.Map<IEnumerable<ReparacionDTO>>(reparaciones);
    }

    [HttpGet("{id}")]
    [SwaggerResponse(200, "Detalles de reparación", typeof(ReparacionDTO))]
    [SwaggerResponse(404, "Reparación no encontrada")]
    public IActionResult GetReparacionById(int id)
    {
        var reparacion = _reparacionRepository.GetById(id);
        if (reparacion == null)
        {
            return NotFound();
        }

        reparacion.CalcularTotal();

        return Ok(_mapper.Map<ReparacionDTO>(reparacion));
    }

    [HttpPost]
    [SwaggerResponse(201, "Reparación creada", typeof(ReparacionDTO))]
    [SwaggerResponse(400, "Solicitud no válida")]
    public IActionResult CreateReparacion([FromBody] ReparacionDTO reparacionDTO)
    {
        var reparacion = _mapper.Map<Reparacion>(reparacionDTO);
        _reparacionRepository.Add(reparacion);
        return CreatedAtAction(nameof(GetReparacionById), new { id = reparacion.Id }, _mapper.Map<ReparacionDTO>(reparacion));
    }

    [HttpPut("{id}")]
    [SwaggerResponse(204, "Reparación actualizada")]
    [SwaggerResponse(400, "Solicitud no válida")]
    [SwaggerResponse(404, "Reparación no encontrada")]
    public IActionResult UpdateReparacion(int id, [FromBody] ReparacionDTO reparacionDTO)
    {
        if (id != reparacionDTO.Id)
        {
            return BadRequest();
        }

        var existingReparacion = _reparacionRepository.GetById(id);
        if (existingReparacion == null)
        {
            return NotFound();
        }

        var reparacion = _mapper.Map<Reparacion>(reparacionDTO);
        _reparacionRepository.Update(reparacion);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerResponse(204, "Reparación eliminada")]
    [SwaggerResponse(404, "Reparación no encontrada")]
    public IActionResult DeleteReparacion(int id)
    {
        var reparacionToDelete = _reparacionRepository.GetById(id);
        if (reparacionToDelete == null)
        {
            return NotFound();
        }

        _reparacionRepository.Delete(id);
        return NoContent();
    }
}
