using API.Controllers.Empresas.Request;
using API.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Empresas;

[ApiController]
[Route("[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly ILogger<EmpresaController> _logger;
    private readonly DbTest3Context db;

    public EmpresaController(ILogger<EmpresaController> logger, DbTest3Context db)
    {
        _logger = logger;
        this.db = db;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<Empresa>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync()
    {
        var documents = await db.Empresas.ToListAsync();
        if (!documents.Any())
            return this.NoContent();

        return this.Ok(documents);
    }

    [HttpGet()]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<List<Empresa>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await db.Empresas.FirstOrDefaultAsync(x => x.Id == id);
        if (document is null)
            return this.NoContent();

        return this.Ok(document);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<Empresa>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync(EmpresaUpsert rowUpsert)
    {
        var document = new Empresa
        {
            Nombre = rowUpsert.Nombre,
            Ruc = rowUpsert.Ruc,
            Telefono = rowUpsert.Telefono,
            Direccion = rowUpsert.Direccion,
            CodigoEmpresa = rowUpsert.CodigoEmpresa
        };

        try
        {
            db.Empresas.Add(document);
            await db.SaveChangesAsync();
            return this.Ok(document);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error al insertar. Message : {e.Message}");
            _logger.LogError($"Error al insertar. StackTrace : {e.StackTrace}");
            return this.BadRequest();
        }
    }

    [HttpPatch()]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<Empresa>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(string id, [FromBody] EmpresaUpsert rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el parámetro.");
        }

        var documentToUpdate = await db.Empresas.FirstOrDefaultAsync(x => x.Id == Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Nombre= rowUpsert.Nombre;
        documentToUpdate.Ruc= rowUpsert.Ruc;
        documentToUpdate.Telefono= rowUpsert.Telefono;
        documentToUpdate.Direccion= rowUpsert.Direccion;
        documentToUpdate.CodigoEmpresa= rowUpsert.CodigoEmpresa;
        documentToUpdate.FechaModificacion= DateTime.Now;

        db.Entry(documentToUpdate).State = EntityState.Modified;

        try
        {
            db.Empresas.Update(documentToUpdate);
            await db.SaveChangesAsync();
            return this.Ok(documentToUpdate);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error al actualizar. Message : {e.Message}");
            Console.WriteLine($"Error al actualizar. StackTrace : {e.StackTrace}");
            return this.BadRequest();
        }
    }

    [HttpPut()]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<Empresa>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(string id, [FromBody] Empresa rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el parámetro.");
        }

        var documentToUpdate = await db.Empresas.FirstOrDefaultAsync(x => x.Id == Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Nombre = rowUpsert.Nombre;
        documentToUpdate.Ruc = rowUpsert.Ruc;
        documentToUpdate.Telefono = rowUpsert.Telefono;
        documentToUpdate.Direccion = rowUpsert.Direccion;
        documentToUpdate.CodigoEmpresa = rowUpsert.CodigoEmpresa;
        documentToUpdate.FechaModificacion = DateTime.Now;

        db.Entry(documentToUpdate).State = EntityState.Modified;

        try
        {
            db.Empresas.Update(documentToUpdate);
            await db.SaveChangesAsync();
            return this.Ok(documentToUpdate);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error al modificar. Message : {e.Message}");
            _logger.LogError($"Error al modificar. StackTrace : {e.StackTrace}");
            return this.BadRequest();
        }
    }

    [HttpDelete()]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<Empresa>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var document = await db.Empresas.FirstOrDefaultAsync(x => x.Id == id);
        if (document is null)
            return this.NoContent();

        try
        {
            db.Empresas.Remove(document);
            await db.SaveChangesAsync();
            return this.Ok(document);
        }
        catch (Exception e)
        {
            _logger.LogError($"Error al eliminar. Message : {e.Message}");
            _logger.LogError($"Error al eliminar. StackTrace : {e.StackTrace}");
            return this.BadRequest();
        }
    }
}

