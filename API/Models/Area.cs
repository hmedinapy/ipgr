using System.Text.Json.Serialization;

namespace API.Models;

public partial class Area
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    public int IdDepartamento { get; set; }

    public int? IdEmpresa { get; set; }
    [JsonIgnore]
    public virtual ICollection<AnalisisRiesgo> AnalisisRiesgos { get; set; } = new List<AnalisisRiesgo>();
    [JsonIgnore]
    public virtual ICollection<DetalleArea> DetalleAreas { get; set; } = new List<DetalleArea>();
    //[JsonIgnore]
    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;
    //[JsonIgnore]
    public virtual Empresa? IdEmpresaNavigation { get; set; }
    [JsonIgnore]
    public virtual ICollection<PlanTrabajo> PlanTrabajos { get; set; } = new List<PlanTrabajo>();
}
