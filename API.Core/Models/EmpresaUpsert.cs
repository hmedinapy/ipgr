namespace API.Core.Models;

public class EmpresaUpsert
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? CodigoEmpresa { get; set; }

    public bool Activo { get; set; } = true;

    public DateTime? FechaCreacion { get; set; } = DateTime.Now;

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }

}
