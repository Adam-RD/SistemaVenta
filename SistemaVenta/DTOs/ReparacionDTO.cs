using Swashbuckle.AspNetCore.Annotations;

[SwaggerSchema(Required = new[] { "Descricion", "Inversion", "ManoObra", "NombreCliente" })]
public class ReparacionDTO
{   
    public int Id { get; set; }
    public string Descricion { get; set; } = string.Empty;
    public double Inversion { get; set; }
    public double ManoObra { get; set; }
    public DateTime Fecha { get; set; }
    public double Total { get; set; }
    public string NombreCliente { get; set; } = string.Empty;
}

