using API.Controllers.Empresas.Request;
using API.Models;
using API.Reposirory.Empresas;
using Azure;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Empresas;

[ApiController]
[Route("[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly ILogger<EmpresaController> _logger;
    private readonly IEmpresaRepository repository;

    public EmpresaController(ILogger<EmpresaController> logger, IEmpresaRepository repository)
    {
        _logger = logger;
        this.repository = repository;
    }

    [HttpGet()]
    [ProducesResponseType(typeof(Response<List<Empresa>>), StatusCodes.Status200OK)]
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
    [ProducesResponseType(typeof(Response<List<Empresa>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await repository.GetOneAsync(id);
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
            CodigoEmpresa = rowUpsert.CodigoEmpresa,
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
    [ProducesResponseType(typeof(Response<Empresa>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(int id, [FromBody] EmpresaUpsert rowUpsert)
    {
        var documentToUpdate = await repository.GetOneAsync(id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Nombre = rowUpsert.Nombre;
        documentToUpdate.Ruc = rowUpsert.Ruc;
        documentToUpdate.Telefono = rowUpsert.Telefono;
        documentToUpdate.Direccion = rowUpsert.Direccion;
        documentToUpdate.CodigoEmpresa = rowUpsert.CodigoEmpresa;

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
    [ProducesResponseType(typeof(Response<Empresa>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PutAsync(int id, [FromBody] EmpresaUpsert rowUpsert)
    {
        var documentToUpdate = await repository.GetOneAsync(id);
        if (documentToUpdate is null)
            return this.NoContent();

        documentToUpdate.Nombre = rowUpsert.Nombre;
        documentToUpdate.Ruc = rowUpsert.Ruc;
        documentToUpdate.Telefono = rowUpsert.Telefono;
        documentToUpdate.Direccion = rowUpsert.Direccion;
        documentToUpdate.CodigoEmpresa = rowUpsert.CodigoEmpresa;

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
    [ProducesResponseType(typeof(Response<Empresa>), StatusCodes.Status200OK)]
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