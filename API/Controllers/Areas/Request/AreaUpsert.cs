namespace API.Controllers.Areas.Request;

public class AreaUpsert
{
    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; } = true;

    public int IdDepartamento { get; set; }

    public int? IdEmpresa { get; set; }

}
