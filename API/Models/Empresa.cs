using System.Text.Json.Serialization;

namespace API.Models;

public partial class Empresa
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Ruc { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? CodigoEmpresa { get; set; }

    public bool Activo { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }
    [JsonIgnore]
    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
    [JsonIgnore]
    public virtual ICollection<Departamento> Departamentos { get; set; } = new List<Departamento>();
}
