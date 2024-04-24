using System.Text.Json.Serialization;

namespace API.Models;

public partial class Area
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public int IdDepartamento { get; set; }

    public int? IdEmpresa { get; set; }

    [JsonIgnore]
    public virtual ICollection<AnalisisRiesgo> AnalisisRiesgos { get; set; } = new List<AnalisisRiesgo>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual Empresa? IdEmpresaNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<PlanTrabajo> PlanTrabajos { get; set; } = new List<PlanTrabajo>();
}
