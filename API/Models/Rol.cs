using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace API.Models;

public partial class Rol
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; } = true;

    [JsonIgnore]
    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}
