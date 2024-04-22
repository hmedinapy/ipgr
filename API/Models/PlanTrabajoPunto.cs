﻿namespace API.Models;

public partial class PlanTrabajoPunto
{
    public int Id { get; set; }

    public int IdPlanTrabajo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string TipoPunto { get; set; } = null!;

    public virtual PlanTrabajo IdPlanTrabajoNavigation { get; set; } = null!;
}
