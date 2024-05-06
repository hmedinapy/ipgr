using Microsoft.AspNetCore.Identity;

namespace API.Models
{
    public class ApiUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
