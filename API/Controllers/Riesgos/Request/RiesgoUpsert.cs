namespace API.Controllers.Riesgos.Request;

public class RiesgoUpsert
{
    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; } = true;

    public DateTime? FechaCreacion { get; set; } = DateTime.Now;

    public int? UsuarioCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }

}
