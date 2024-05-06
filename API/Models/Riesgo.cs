using System;
using System.Collections.Generic;

namespace API.Models;

public partial class Riesgo
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? UserCreado { get; set; }

    public bool? Activo { get; set; }

    public virtual ICollection<AnalisisRiesgo> AnalisisRiesgos { get; set; } = new List<AnalisisRiesgo>();
}
