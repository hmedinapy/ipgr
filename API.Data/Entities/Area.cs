using System;
using System.Collections.Generic;

namespace API.Data.Entities;

public partial class Area
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public int IdDepartamento { get; set; }

    public int? IdEmpresa { get; set; }

    public virtual ICollection<AnalisisRiesgo> AnalisisRiesgos { get; set; } = new List<AnalisisRiesgo>();

    public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
