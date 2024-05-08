using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities
{
    public class ApiUser : IdentityUser
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
    }
}
