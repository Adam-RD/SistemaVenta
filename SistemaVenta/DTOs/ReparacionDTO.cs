using Swashbuckle.AspNetCore.Annotations;

[SwaggerSchema(Required = new[] { "Descricion", "Inversion", "ManoObra", "NombreCliente" })]
public class ReparacionDTO
{   
    public int Id { get; set; }
    public string Descricion { get; set; } = string.Empty;
    public double Inversion { get; set; } = 0;
    public double ManoObra { get; set; } = 0;
    DateTime Fecha { get; set; } = DateTime.Now;
    public double Total { get; set; } = 0;
    public string NombreCliente { get; set; } = string.Empty;

    public double Descento { get; set; } = 0;



}

