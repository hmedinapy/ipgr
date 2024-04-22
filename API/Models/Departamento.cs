using System.Text.Json.Serialization;

namespace API.Models;

public partial class Departamento
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdEmpresa { get; set; }

    public bool Estado { get; set; }
    [JsonIgnore]
    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();
    [JsonIgnore]
    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;
}
