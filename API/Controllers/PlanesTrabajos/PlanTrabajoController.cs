using API.Controllers.PlanesTrabajos.Request;
using API.Models;
using API.Reposirory.PlanesTrabajos;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.PlanesTrabajos;

[ApiController]
[Route("[controller]")]
public class PlanTrabajoController : ControllerBase
{
    private readonly ILogger<PlanTrabajoController> _logger;
    private readonly IPlanTrabajoRepository repository;

    public PlanTrabajoController(ILogger<PlanTrabajoController> logger, IPlanTrabajoRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<PlanTrabajo>>), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(Response<List<PlanTrabajo>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await repository.GetOneAsync(id);
        if (document is null)
            return this.NoContent();

        return this.Ok(document);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync(PlanTrabajoUpsert rowUpsert)
    {
        var document = new PlanTrabajo
        {
            Numero = rowUpsert.Numero,
            Codigo = rowUpsert.Codigo,
            // IdDetalleArea = rowUpsert.IdDetalleArea,
            IdDepartamento = rowUpsert.IdDepartamento,
            Objetivos = rowUpsert.Objetivos,
            Procedimientos = rowUpsert.Procedimientos,
            CantidadPersonas = rowUpsert.CantidadPersonas,
            HorasNetas = rowUpsert.HorasNetas,
            Productos = rowUpsert.Productos,
            FechaIncioAuditoria = rowUpsert.FechaIncioAuditoria,
            FechaFinAuditoria = rowUpsert.FechaFinAuditoria,
            IdAuditorAsignado = rowUpsert.IdAuditorAsignado,
            IdResponsableAreaAuditada = rowUpsert.IdResponsableAreaAuditada,
            IdAreaAuditada = rowUpsert.IdAreaAuditada,
            Estado = rowUpsert.Estado,
            EnvioInforme = rowUpsert.EnvioInforme,
            FechaCreada = rowUpsert.FechaCreada,
            IdUserCreada = rowUpsert.IdUserCreada
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
    [ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(int id, [FromBody] PlanTrabajoUpsert rowUpsert)
    {
        var documentToUpdate = await repository.GetOneAsync(id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Numero = rowUpsert.Numero;
        documentToUpdate.Codigo = rowUpsert.Codigo;
        //documentToUpdate.IdDetalleArea = rowUpsert.IdDetalleArea;
        documentToUpdate.IdDepartamento = rowUpsert.IdDepartamento;
        documentToUpdate.Objetivos = rowUpsert.Objetivos;
        documentToUpdate.Procedimientos = rowUpsert.Procedimientos;
        documentToUpdate.CantidadPersonas = rowUpsert.CantidadPersonas;
        documentToUpdate.HorasNetas = rowUpsert.HorasNetas;
        documentToUpdate.Productos = rowUpsert.Productos;
        documentToUpdate.FechaIncioAuditoria = rowUpsert.FechaIncioAuditoria;
        documentToUpdate.FechaFinAuditoria = rowUpsert.FechaFinAuditoria;
        documentToUpdate.IdAuditorAsignado = rowUpsert.IdAuditorAsignado;
        documentToUpdate.IdResponsableAreaAuditada = rowUpsert.IdResponsableAreaAuditada;
        documentToUpdate.IdAreaAuditada = rowUpsert.IdAreaAuditada;
        documentToUpdate.Estado = rowUpsert.Estado;
        documentToUpdate.EnvioInforme = rowUpsert.EnvioInforme;
        documentToUpdate.FechaCreada = rowUpsert.FechaCreada;
        documentToUpdate.IdUserCreada = rowUpsert.IdUserCreada;

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
    [ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(int id, [FromBody] PlanTrabajoUpsert rowUpsert)
    {
        var documentToUpdate = await repository.GetOneAsync(id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Numero = rowUpsert.Numero;
        documentToUpdate.Codigo = rowUpsert.Codigo;
        //documentToUpdate.IdDetalleArea = rowUpsert.IdDetalleArea;
        documentToUpdate.IdDepartamento = rowUpsert.IdDepartamento;
        documentToUpdate.Objetivos = rowUpsert.Objetivos;
        documentToUpdate.Procedimientos = rowUpsert.Procedimientos;
        documentToUpdate.CantidadPersonas = rowUpsert.CantidadPersonas;
        documentToUpdate.HorasNetas = rowUpsert.HorasNetas;
        documentToUpdate.Productos = rowUpsert.Productos;
        documentToUpdate.FechaIncioAuditoria = rowUpsert.FechaIncioAuditoria;
        documentToUpdate.FechaFinAuditoria = rowUpsert.FechaFinAuditoria;
        documentToUpdate.IdAuditorAsignado = rowUpsert.IdAuditorAsignado;
        documentToUpdate.IdResponsableAreaAuditada = rowUpsert.IdResponsableAreaAuditada;
        documentToUpdate.IdAreaAuditada = rowUpsert.IdAreaAuditada;
        documentToUpdate.Estado = rowUpsert.Estado;
        documentToUpdate.EnvioInforme = rowUpsert.EnvioInforme;
        documentToUpdate.FechaCreada = rowUpsert.FechaCreada;
        documentToUpdate.IdUserCreada = rowUpsert.IdUserCreada;

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
    [ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
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