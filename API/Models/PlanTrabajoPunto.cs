using System;
using System.Collections.Generic;

namespace API.Models;

public partial class PlanTrabajoPunto
{
    public int Id { get; set; }

    public int IdPlanTrabajo { get; set; }

    public string Descripcion { get; set; } = null!;

    public string TipoPunto { get; set; } = null!;

    public bool? Activo { get; set; }

    public virtual PlanTrabajo IdPlanTrabajoNavigation { get; set; } = null!;
}
