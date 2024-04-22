namespace API.Models;

public partial class Dependencium
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<PlanTrabajo> PlanTrabajos { get; set; } = new List<PlanTrabajo>();
}
