using SistemaVenta.Model;
using System.Collections.Generic;

public interface IReparacionRepository
{
    IEnumerable<Reparacion> GetAll();
    Reparacion GetById(int id);
    IEnumerable<Reparacion> BuscarReparacionesPorRangoDeFechas(DateTime fechaInicio, DateTime fechaFin);
    void Add(Reparacion reparacion);
    void Update(Reparacion reparacion);
    void Delete(int id);
}

