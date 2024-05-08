using API.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Core.DTOs
{
    public class RiesgoDTO
    {
        public string Descripcion { get; set; } = null!;

        public int? UserCreado { get; set; }

        //public bool? Activo { get; set; }
    }
}