namespace API.Data.Entities;

public partial class Departamento
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int IdEmpresa { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<PlanTrabajo> PlanTrabajos { get; set; } = new List<PlanTrabajo>();
}
