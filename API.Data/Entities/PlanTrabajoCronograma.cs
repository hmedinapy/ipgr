using System;
using System.Collections.Generic;

namespace API.Data.Entities;

public partial class PlanTrabajoCronograma
{
    public int Id { get; set; }

    public int IdPlanTrabajo { get; set; }

    public DateOnly Fecha { get; set; }

    public int CantidadHoras { get; set; }

    public virtual PlanTrabajo IdPlanTrabajoNavigation { get; set; } = null!;
}
