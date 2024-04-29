using API.Controllers.Roles.Request;
using API.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Roles;

[ApiController]
[Route("[controller]")]
public class RolController : ControllerBase
{
    private readonly ILogger<RolController> _logger;
    private readonly DbTest3Context db;

    public RolController(ILogger<RolController> logger, DbTest3Context db)
    {
        _logger = logger;
        this.db = db;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<Rol>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync()
    {
        var documents = await db.Roles.ToListAsync();
        if (!documents.Any())
            return this.NoContent();

        return this.Ok(documents);
    }

    [HttpGet()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<List<Rol>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await db.Roles.FirstOrDefaultAsync(x => x.Id == id);
        if (document is null)
            return this.NoContent();

        return this.Ok(document);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<Rol>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync(RolUpsert rowUpsert)
    {
        var document = new Rol
        {
            Descripcion = rowUpsert.Descripcion
        };

        try
        {
            db.Roles.Add(document);
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
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<Rol>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(int id, [FromBody] RolUpsert rowUpsert)
    {
        var documentToUpdate = await db.Roles.FirstOrDefaultAsync(x => x.Id == id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        db.Entry(documentToUpdate).State = EntityState.Modified;

        try
        {
            db.Roles.Update(documentToUpdate);
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
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<Rol>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(int id, [FromBody] Rol rowUpsert)
    {
        var documentToUpdate = await db.Roles.FirstOrDefaultAsync(x => x.Id == id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        db.Entry(documentToUpdate).State = EntityState.Modified;

        try
        {
            db.Roles.Update(documentToUpdate);
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
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<Rol>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var document = await db.Roles.FirstOrDefaultAsync(x => x.Id == id);
        if (document is null)
            return this.NoContent();

        try
        {
            db.Roles.Remove(document);
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

