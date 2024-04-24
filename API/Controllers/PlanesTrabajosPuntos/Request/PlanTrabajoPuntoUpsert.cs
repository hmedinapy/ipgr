namespace API.Controllers.PlanesTrabajosPuntos.Request;

public class PlanTrabajoPuntoUpsert
{
    public int IdPlanTrabajo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string TipoPunto { get; set; } = null!;
    public bool Activo { get; set; } = true;
}
