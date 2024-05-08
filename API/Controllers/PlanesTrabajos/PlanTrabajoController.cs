using API.Core.DTOs;
using API.Core.Models;
using API.Core.Repository;
using API.Data.Entities;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.PlanesTrabajos;

[ApiController]
[Route("[controller]")]
public class PlanTrabajoController : ControllerBase
{
    private readonly ILogger<PlanTrabajoController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlanTrabajoController(ILogger<PlanTrabajoController> logger, IUnitOfWork _unitOfWork, IMapper mapper)
    {
        _logger = logger;
        this._unitOfWork = _unitOfWork;
        _mapper = mapper;
    }

    [HttpGet()]
    //[ProducesResponseType(typeof(Response<List<PlanTrabajo>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync([FromQuery] RequestParams requestParams)
    {
        var documents = await _unitOfWork.PlanesTrabajos.GetPagedList(requestParams);
        var results = _mapper.Map<IList<PlanTrabajoDTO>>(documents);
        return Ok(results);
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet()]
    [Route("{id:int}")]
    //[ProducesResponseType(typeof(Response<List<PlanTrabajo>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await _unitOfWork.PlanesTrabajos.Get(q => q.Id == id,
            include: a => a.Include(x => x.IdAreaAuditadaNavigation)
            );
        var result = _mapper.Map<PlanTrabajoDTO>(document);
        return Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync([FromBody] PlanTrabajoUpsert rowUpsert)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(PostAsync)}");
            return BadRequest(ModelState);
        }

        var document = _mapper.Map<PlanTrabajo>(rowUpsert);
        await _unitOfWork.PlanesTrabajos.Insert(document);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetOneAsync", new { id = document.Id }, document);
    }

    [HttpPatch()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(int id, [FromBody] PlanTrabajoUpsert rowUpsert)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(PostAsync)}");
            return BadRequest(ModelState);
        }

        var document = await _unitOfWork.PlanesTrabajos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        document.Numero = rowUpsert.Numero;
        document.Codigo = rowUpsert.Codigo;
        document.IdDetalleArea = rowUpsert.IdDetalleArea;
        document.IdDepartamento = rowUpsert.IdDepartamento;
        document.Objetivos = rowUpsert.Objetivos;
        document.Procedimientos = rowUpsert.Procedimientos;
        document.CantidadPersonas = rowUpsert.CantidadPersonas;
        document.HorasNetas = rowUpsert.HorasNetas;
        document.Productos = rowUpsert.Productos;
        document.FechaIncioAuditoria = rowUpsert.FechaIncioAuditoria;
        document.FechaFinAuditoria = rowUpsert.FechaFinAuditoria;
        document.IdAuditorAsignado = rowUpsert.IdAuditorAsignado;
        document.IdResponsableAreaAuditada = rowUpsert.IdResponsableAreaAuditada;
        document.IdAreaAuditada = rowUpsert.IdAreaAuditada;
        document.Estado = rowUpsert.Estado;
        document.EnvioInforme = rowUpsert.EnvioInforme;
        document.FechaCreada = rowUpsert.FechaCreada;
        document.IdUserCreada = rowUpsert.IdUserCreada;
        document.Activo = rowUpsert.Activo;

        _unitOfWork.PlanesTrabajos.Update(document);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetOneAsync", new { id = document.Id }, document);
    }

    [HttpPut()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] PlanTrabajoUpsert rowUpsert)
    {
        if (!ModelState.IsValid || id < 1)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest(ModelState);
        }


        var document = await _unitOfWork.PlanesTrabajos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        _mapper.Map(rowUpsert, document);
        _unitOfWork.PlanesTrabajos.Update(document);
        await _unitOfWork.Save();

        return Ok();
    }

    [HttpPatch()]
    [Route("active/{id:int}")]
    [ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        if (id < 1)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAsync)}");
            return BadRequest();
        }

        var document = await _unitOfWork.PlanesTrabajos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        document.Activo = false;
        _unitOfWork.PlanesTrabajos.Update(document);
        await _unitOfWork.Save();

        return Ok();
    }

    //[HttpDelete()]
    //[Route("/hard/{id:int}")]
    //[ProducesResponseType(typeof(Response<PlanTrabajo>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //public async Task<ActionResult> DeleteHardAsync(int id)
    //{
    //    if (id < 1)
    //    {
    //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHardAsync)}");
    //        return BadRequest();
    //    }

    //    var document = await _unitOfWork.PlanesTrabajos.Get(q => q.Id == id);
    //    if (document == null)
    //    {
    //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHardAsync)}");
    //        return BadRequest("Submitted data is invalid");
    //    }

    //    await _unitOfWork.PlanesTrabajos.Delete(id);
    //    await _unitOfWork.Save();

    //    return Ok();
    //}
}