using System.Text.Json.Serialization;

namespace API.Models;

public partial class UserRol
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public bool Estado { get; set; }

    [JsonIgnore]
    public virtual Rol IdRolNavigation { get; set; } = null!;
    [JsonIgnore]
    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
