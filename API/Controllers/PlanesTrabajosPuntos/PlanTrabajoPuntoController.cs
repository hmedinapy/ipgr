using API.Controllers.PlanesTrabajosPuntos.Request;
using API.Models;
using API.Reposirory.PlanesTrabajosPuntos;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.PlanesTrabajosPuntos;

[ApiController]
[Route("[controller]")]
public class PlanTrabajoPuntoController : ControllerBase
{
    private readonly ILogger<PlanTrabajoPuntoController> _logger;
    private readonly IPlanTrabajoPuntoRepository repository;

    public PlanTrabajoPuntoController(ILogger<PlanTrabajoPuntoController> logger, IPlanTrabajoPuntoRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<PlanTrabajoPunto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync()
    {
        var documents = await repository.GetAllAsync();
        if (!documents.Any())
            return this.NoContent();

        return this.Ok(documents);
    }

    [HttpGet()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<List<PlanTrabajoPunto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await repository.GetOneAsync(id);
        if (document is null)
            return this.NoContent();

        return this.Ok(document);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync(PlanTrabajoPuntoUpsert rowUpsert)
    {
        var document = new PlanTrabajoPunto
        {
            Descripcion = rowUpsert.Descripcion,
            TipoPunto = rowUpsert.TipoPunto
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
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(int id, [FromBody] PlanTrabajoPuntoUpsert rowUpsert)
    {
        var documentToUpdate = await repository.GetOneAsync(id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        documentToUpdate.TipoPunto = rowUpsert.TipoPunto;

        try
        {
            await repository.UpdateAsync(documentToUpdate);
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
    [ProducesResponseType(typeof(Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(int id, [FromBody] PlanTrabajoPuntoUpsert rowUpsert)
    {
        var documentToUpdate = await repository.GetOneAsync(id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        documentToUpdate.TipoPunto = rowUpsert.TipoPunto;

        try
        {
            await repository.UpdateAsync(documentToUpdate);
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
    [ProducesResponseType(typeof(Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        var document = await repository.GetOneAsync(id);
        if (document is null)
            return this.NoContent();

        try
        {
            // borrado lógico
            document.Activo = false;
            await repository.UpdateAsync(document);

            // borrado fìsico
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