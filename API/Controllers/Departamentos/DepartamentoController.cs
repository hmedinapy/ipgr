using API.Controllers.Departamentos.Request;
using API.Models;
using API.Reposirory.Departamentos;
using API.Reposirory.Empresas;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Departamentos;

[ApiController]
[Route("[controller]")]
public class DepartamentoController : ControllerBase
{
    private readonly ILogger<DepartamentoController> _logger;
    private readonly IDepartamentoRepository repository;

    public DepartamentoController(ILogger<DepartamentoController> logger, IDepartamentoRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<Departamento>>), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(Response<List<Departamento>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await repository.GetOneAsync(id);
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
    [ProducesResponseType(typeof(Response<Departamento>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(string id, [FromBody] DepartamentoUpsert rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el parámetro.");
        }

        var documentToUpdate = await repository.GetOneAsync(Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        documentToUpdate.IdEmpresa = rowUpsert.IdEmpresa;

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
    [ProducesResponseType(typeof(Response<Departamento>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(string id, [FromBody] DepartamentoUpsert rowUpsert)
    {
        int Id = 0;
        if (!int.TryParse(id, out Id))
        {
            return this.BadRequest("Error en el parámetro.");
        }

        var documentToUpdate = await repository.GetOneAsync(Id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Descripcion = rowUpsert.Descripcion;
        documentToUpdate.IdEmpresa = rowUpsert.IdEmpresa;

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
    [ProducesResponseType(typeof(Response<Departamento>), StatusCodes.Status200OK)]
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