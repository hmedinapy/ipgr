namespace API.Core.Models;

public class DepartamentoUpsert
{
    public string Descripcion { get; set; } = null!;

    public int IdEmpresa { get; set; }

    public bool Activo { get; set; } = true;

}
