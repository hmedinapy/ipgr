using System.Text.Json.Serialization;

namespace API.Models;

public partial class Riesgo
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? UserCreado { get; set; }

    public bool? Activo { get; set; }
    [JsonIgnore]
    public virtual ICollection<AnalisisRiesgo> AnalisisRiesgos { get; set; } = new List<AnalisisRiesgo>();
}
