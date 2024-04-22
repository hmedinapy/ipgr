using API.Controllers.Areas.Request;
using API.Models;
using API.Reposirory.Areas;
using Azure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Areas;

[ApiController]
[Route("[controller]")]
public class AreaController : ControllerBase
{
    private readonly ILogger<AreaController> _logger;
    private readonly IAreaRepository repository;

    public AreaController(ILogger<AreaController> logger, IAreaRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<Area>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync()
    {
        //var documents = await db.Areas
        //    .Include(x => x.IdDepartamentoNavigation)
        //    .Include(x => x.IdEmpresaNavigation)
        //    .ToListAsync();
        var documents = await repository.GetAllAsync();
        if (!documents.Any())
            return this.NoContent();

        return this.Ok(documents);
    }

    [HttpGet()]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<List<Area>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        //var document = await db.Areas
        //    .Include(x => x.IdDepartamentoNavigation)
        //    .Include(x => x.IdEmpresaNavigation)
        //    .FirstOrDefaultAsync(x => x.Id == id);
        var document = await repository.GetOneAsync(id);
        if (document is null)
            return this.NoContent();

        return this.Ok(document);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<Area>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync(AreaUpsert rowUpsert)
    {
        var document = new Area
        {
            Descripcion = rowUpsert.Descripcion,
            IdDepartamento = rowUpsert.IdDepartamento,
            IdEmpresa = rowUpsert.IdEmpresa
        };

        try
        {
            await repository.AddRowAsync(document);
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
    [ProducesResponseType(typeof(Response<Area>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(string id, [FromBody] AreaUpsert rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el par�metro.");
        }

        //var documentToUpdate = await db.Areas.FirstOrDefaultAsync(x => x.Id == Id);
        var documentToUpdate = await repository.GetOneAsync(Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        documentToUpdate.IdEmpresa = rowUpsert.IdEmpresa;

        //db.Entry(documentToUpdate).State = EntityState.Modified;

        try
        {
            await repository.UpdateAsync(documentToUpdate);
            //db.Areas.Update(documentToUpdate);
            //await db.SaveChangesAsync();
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
    [ProducesResponseType(typeof(Response<Area>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(string id, [FromBody] AreaUpsert rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el par�metro.");
        }

        //var documentToUpdate = await db.Areas.FirstOrDefaultAsync(x => x.Id == Id);
        var documentToUpdate = await repository.GetOneAsync(Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        documentToUpdate.IdEmpresa = rowUpsert.IdEmpresa;

        //db.Entry(documentToUpdate).State = EntityState.Modified;

        try
        {
            await repository.UpdateAsync(documentToUpdate);
            //db.Areas.Update(documentToUpdate);
            //await db.SaveChangesAsync();
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
    [ProducesResponseType(typeof(Response<Area>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        //var document = await db.Areas.FirstOrDefaultAsync(x => x.Id == id);
        var document = await repository.GetOneAsync(id);
        if (document is null)
            return this.NoContent();

        try
        {
            // borrado l�gico
            document.Estado = false;
            await repository.UpdateAsync(document);
            // borrado f�sico
            //await repository.RemoveAsync(document);
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
