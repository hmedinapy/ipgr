using System;
using System.Collections.Generic;

namespace API.Data.Entities;

public partial class PlanTrabajo
{
    public int Id { get; set; }

    public int? Numero { get; set; }

    public string? Codigo { get; set; }

    public int? IdDetalleArea { get; set; }

    public int? IdDepartamento { get; set; }

    public string? Objetivos { get; set; }

    public string? Procedimientos { get; set; }

    public int? CantidadPersonas { get; set; }

    public int? HorasNetas { get; set; }

    public int? Productos { get; set; }

    public DateOnly FechaIncioAuditoria { get; set; }

    public DateOnly FechaFinAuditoria { get; set; }

    public int? IdAuditorAsignado { get; set; }

    public int? IdResponsableAreaAuditada { get; set; }

    public int? IdAreaAuditada { get; set; }

    public string Estado { get; set; } = null!;

    public string? EnvioInforme { get; set; }

    public DateOnly FechaCreada { get; set; }

    public int IdUserCreada { get; set; }

    public bool? Activo { get; set; }

    public virtual Area? IdAreaAuditadaNavigation { get; set; }

    public virtual Usuario? IdAuditorAsignadoNavigation { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }

    public virtual Usuario? IdResponsableAreaAuditadaNavigation { get; set; }

    public virtual ICollection<PlanTrabajoPunto> PlanTrabajoPuntos { get; set; } = new List<PlanTrabajoPunto>();
}
