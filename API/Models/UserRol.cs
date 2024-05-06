using System;
using System.Collections.Generic;

namespace API.Models;

public partial class UserRol
{
    public int Id { get; set; }

    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public bool Activo { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
