using System.Text.Json.Serialization;

namespace API.Models;

public partial class Rol
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }
    [JsonIgnore]
    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}
