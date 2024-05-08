using API.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Core.DTOs
{
    public class AreaDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Descripcion es limitado de {6} a {50} caracteres", MinimumLength = 6)]
        public string Descripcion { get; set; } = null!;

        public bool Activo { get; set; } = true;

        public int IdDepartamento { get; set; }

        public int? IdEmpresa { get; set; }

        public virtual IList<AnalisisRiesgo> AnalisisRiesgos { get; set; } = new List<AnalisisRiesgo>();

        public virtual Departamento IdDepartamentoNavigation { get; set; } = null!;

        public virtual Empresa? IdEmpresaNavigation { get; set; }

        public virtual IList<PlanTrabajo> PlanTrabajos { get; set; } = new List<PlanTrabajo>();
    }

}