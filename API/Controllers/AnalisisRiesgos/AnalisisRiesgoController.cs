using API.Controllers.AnalisisRiesgos.Request;
using API.Models;
using API.Reposirory;
using API.Reposirory.AnalisisRiesgos;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.AnalisisRiesgos;

[ApiController]
[Route("[controller]")]
public class AnalisisRiesgoController : ControllerBase
{
    private readonly ILogger<AnalisisRiesgoController> _logger;
    private readonly IAnalisisRiesgoRepository repository;

    public AnalisisRiesgoController(ILogger<AnalisisRiesgoController> logger, IAnalisisRiesgoRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<AnalisisRiesgo>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync()
    {
        var documents = await repository.GetAllAsync();
        if (!documents.Any())
            return this.NoContent();

        return this.Ok(documents);
    }

    [HttpGet()]
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<List<AnalisisRiesgo>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await repository.GetOneAsync(id);
        if (document is null)
            return this.NoContent();

        return this.Ok(document);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync(AnalisisRiesgoUpsert rowUpsert)
    {
        var document = new AnalisisRiesgo
        {
            IdArea = rowUpsert.IdArea,
            IdRiesgo = rowUpsert.IdRiesgo,
            Significado = rowUpsert.Significado,
            AgenteGenerador = rowUpsert.AgenteGenerador,
            Causa = rowUpsert.Causa,
            Efecto = rowUpsert.Efecto,
            Probabilidad = rowUpsert.Probabilidad,
            Impacto = rowUpsert.Impacto,
            Resultado = rowUpsert.Resultado,
            NivelRiesgo = rowUpsert.NivelRiesgo
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
    [ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(string id, [FromBody] AnalisisRiesgoUpsert rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el parámetro.");
        }

        var documentToUpdate = await repository.GetOneAsync(Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.IdArea = rowUpsert.IdArea;
        documentToUpdate.IdRiesgo = rowUpsert.IdRiesgo;
        documentToUpdate.Significado = rowUpsert.Significado;
        documentToUpdate.AgenteGenerador = rowUpsert.AgenteGenerador;
        documentToUpdate.Causa = rowUpsert.Causa;
        documentToUpdate.Efecto = rowUpsert.Efecto;
        documentToUpdate.Probabilidad = rowUpsert.Probabilidad;
        documentToUpdate.Impacto = rowUpsert.Impacto;
        documentToUpdate.Resultado = rowUpsert.Resultado;
        documentToUpdate.NivelRiesgo = rowUpsert.NivelRiesgo;

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
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(string id, [FromBody] AnalisisRiesgoUpsert rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el parámetro.");
        }

        var documentToUpdate = await repository.GetOneAsync(Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.IdArea = rowUpsert.IdArea;
        documentToUpdate.IdRiesgo = rowUpsert.IdRiesgo;
        documentToUpdate.Significado = rowUpsert.Significado;
        documentToUpdate.AgenteGenerador = rowUpsert.AgenteGenerador;
        documentToUpdate.Causa = rowUpsert.Causa;
        documentToUpdate.Efecto = rowUpsert.Efecto;
        documentToUpdate.Probabilidad = rowUpsert.Probabilidad;
        documentToUpdate.Impacto = rowUpsert.Impacto;
        documentToUpdate.Resultado = rowUpsert.Resultado;
        documentToUpdate.NivelRiesgo = rowUpsert.NivelRiesgo;

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
    [Route("{id}")]
    [ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
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

