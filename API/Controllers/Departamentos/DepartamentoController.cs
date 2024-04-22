using API.Controllers.Departamentos.Request;
using API.Models;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Departamentos;

[ApiController]
[Route("[controller]")]
public class DepartamentoController : ControllerBase
{
    private readonly ILogger<DepartamentoController> _logger;
    private readonly DbTest3Context db;

    public DepartamentoController(ILogger<DepartamentoController> logger, DbTest3Context db)
    {
        _logger = logger;
        this.db = db;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<Departamento>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync()
    {
        var documents = await db.Departamentos.ToListAsync();
        if (!documents.Any())
            return this.NoContent();

        return this.Ok(documents);
    }

    [HttpGet()]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<List<Departamento>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await db.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
        if (document is null)
            return this.NoContent();

        return this.Ok(document);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<Departamento>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync(DepartamentoUpsert rowUpsert)
    {
        var document = new Departamento
        {
            Descripcion = rowUpsert.Descripcion,
            IdEmpresa = rowUpsert.IdEmpresa
        };

        try
        {
            db.Departamentos.Add(document);
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
    [ProducesResponseType(typeof(Response<Departamento>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(string id, [FromBody] DepartamentoUpsert rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el parámetro.");
        }

        var documentToUpdate = await db.Departamentos.FirstOrDefaultAsync(x => x.Id == Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        documentToUpdate.IdEmpresa = rowUpsert.IdEmpresa;

        db.Entry(documentToUpdate).State = EntityState.Modified;

        try
        {
            db.Departamentos.Update(documentToUpdate);
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
    [ProducesResponseType(typeof(Response<Departamento>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(string id, [FromBody] Departamento rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el parámetro.");
        }

        var documentToUpdate = await db.Departamentos.FirstOrDefaultAsync(x => x.Id == Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        documentToUpdate.IdEmpresa = rowUpsert.IdEmpresa;

        db.Entry(documentToUpdate).State = EntityState.Modified;

        try
        {
            db.Departamentos.Update(documentToUpdate);
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
    [ProducesResponseType(typeof(Response<Departamento>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var document = await db.Departamentos.FirstOrDefaultAsync(x => x.Id == id);
        if (document is null)
            return this.NoContent();

        try
        {
            db.Departamentos.Remove(document);
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

