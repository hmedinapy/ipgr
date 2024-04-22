namespace API.Models;

public partial class DetalleArea
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? IdArea { get; set; }

    public bool Estado { get; set; }

    public int? IdUserModify { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual ICollection<PlanTrabajo> PlanTrabajos { get; set; } = new List<PlanTrabajo>();
}
