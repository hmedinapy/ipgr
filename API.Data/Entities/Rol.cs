using System;
using System.Collections.Generic;

namespace API.Data.Entities;

public partial class Rol
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public virtual ICollection<UserRol> UserRols { get; set; } = new List<UserRol>();
}
