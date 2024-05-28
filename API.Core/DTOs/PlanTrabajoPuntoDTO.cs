using API.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Core.DTOs
{
    public class PlanTrabajoPuntoDTO
    {
        public int Id { get; set; }
        public int IdPlanTrabajo { get; set; }

        public string Descripcion { get; set; } = null!;

        public string TipoPunto { get; set; } = null!;

        public bool? Activo { get; set; }

        public virtual PlanTrabajo IdPlanTrabajoNavigation { get; set; } = null!;
    }
}