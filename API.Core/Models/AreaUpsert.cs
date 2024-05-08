namespace API.Core.Models;

public class AreaUpsert
{
    public string Descripcion { get; set; } = null!;

    public int IdDepartamento { get; set; }

    public int? IdEmpresa { get; set; }
}

public class AreaDelete
{
    public bool Activo { get; set; }
}
