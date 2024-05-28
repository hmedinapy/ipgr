using Microsoft.AspNetCore.Identity;

namespace API.Data.Entities;

public partial class ApiUser : IdentityUser
{
    public string? Nombre { get; set; } = null!;
    public string? Apellido { get; set; } = null!;
}
