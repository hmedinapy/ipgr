using System.Text.Json.Serialization;

namespace API.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public int IdEmpresa { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Usuario1 { get; set; } = null!;

    public string Clave { get; set; } = null!;

    public bool Activo { get; set; }

    public string Telefono { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public DateOnly FechaCreada { get; set; }
    [JsonIgnore]
    public virtual ICollection<PlanTrabajo> PlanTrabajoIdAuditorAsignadoNavigations { get; set; } = new List<PlanTrabajo>();
    [JsonIgnore]
    public virtual ICollection<PlanTrabajo> PlanTrabajoIdResponsableAreaAuditadaNavigations { get; set; } = new List<PlanTrabajo>();
    [JsonIgnore]
    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}
