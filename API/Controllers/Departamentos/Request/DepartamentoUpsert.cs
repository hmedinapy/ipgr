namespace API.Controllers.Departamentos.Request;

public class DepartamentoUpsert
{
    public string Descripcion { get; set; } = null!;

    public int IdEmpresa { get; set; }

    public bool Estado { get; set; } = true;

}
