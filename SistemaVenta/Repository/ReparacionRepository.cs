using SistemaVenta.Model;
using System.Collections.Generic;
using System.Linq;

public class ReparacionRepository : IReparacionRepository
{
    private readonly AplicationDbContext _context;

    public ReparacionRepository(AplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Reparacion> GetAll()
    {
        return _context.Reparaciones.ToList();
    }

    public Reparacion GetById(int id)
    {
        return _context.Reparaciones.FirstOrDefault(r => r.Id == id);
    }
    public IEnumerable<Reparacion> BuscarReparacionesPorRangoDeFechas(DateTime fechaInicio, DateTime fechaFin)
    {
        return _context.Reparaciones
            .Where(r => r.Fecha.Date >= fechaInicio.Date && r.Fecha.Date <= fechaFin.Date)
            .ToList();
    }


    public void Add(Reparacion reparacion)
    {
        _context.Reparaciones.Add(reparacion);
        _context.SaveChanges();
    }

    public void Update(Reparacion reparacion)
    {
        _context.Reparaciones.Update(reparacion);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var reparacion = _context.Reparaciones.Find(id);
        if (reparacion != null)
        {
            _context.Reparaciones.Remove(reparacion);
            _context.SaveChanges();
        }
    }
}
