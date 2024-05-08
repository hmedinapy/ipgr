using System;
using System.Collections.Generic;

namespace API.Data.Entities;

public partial class AnalisisRiesgo
{
    public int Id { get; set; }

    public int? IdArea { get; set; }

    public int? IdRiesgo { get; set; }

    public string? Significado { get; set; }

    public string? AgenteGenerador { get; set; }

    public string Causa { get; set; } = null!;

    public string Efecto { get; set; } = null!;

    public int Probabilidad { get; set; }

    public int Impacto { get; set; }

    public int Resultado { get; set; }

    public string? NivelRiesgo { get; set; }

    public bool? Activo { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual Riesgo? IdRiesgoNavigation { get; set; }
}
