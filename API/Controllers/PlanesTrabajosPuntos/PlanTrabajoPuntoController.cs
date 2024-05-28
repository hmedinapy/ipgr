using API.Core.DTOs;
using API.Core.Models;
using API.Core.Repository;
using API.Core.Services;
using API.Data.Entities;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.PlanesTrabajosPuntos;

[ApiController]
[Route("[controller]")]
public class PlanTrabajoPuntoController : ControllerBase
{
    private readonly ILogger<PlanTrabajoPuntoController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PlanTrabajoPuntoController(ILogger<PlanTrabajoPuntoController> logger, IUnitOfWork _unitOfWork, IMapper mapper)
    {
        _logger = logger;
        this._unitOfWork = _unitOfWork;
        _mapper = mapper;
    }

    [HttpGet()]
    //[ProducesResponseType(typeof(Core.Services.Response<List<PlanTrabajoPunto>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync([FromQuery] RequestParams requestParams)
    {
        var documents = await _unitOfWork.PlanesTrabajosPuntos.GetPagedList(requestParams);
        if (documents.Count == 0)
            return NoContent();

        var results = _mapper.Map<IList<PlanTrabajoPuntoDTO>>(documents);
        return Ok(results);
    }

    //[Authorize(Roles = "Administrador")]
    [HttpGet()]
    [Route("{id:int}")]
    //[ProducesResponseType(typeof(Core.Services.Response<List<PlanTrabajoPunto>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await _unitOfWork.PlanesTrabajosPuntos.Get(q => q.Id == id,
            include: q => q.Include(x => x.IdPlanTrabajoNavigation)
            );
        if (document == null)
            return NoContent();

        var result = _mapper.Map<PlanTrabajoPuntoDTO>(document);
        return Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Core.Services.Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync([FromBody] PlanTrabajoPuntoUpsert rowUpsert)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(PostAsync)}");
            return BadRequest(ModelState);
        }

        var document = _mapper.Map<PlanTrabajoPunto>(rowUpsert);
        await _unitOfWork.PlanesTrabajosPuntos.Insert(document);
        await _unitOfWork.Save();

        return Ok(document); //return CreatedAtRoute("GetOneAsync", new { id = document.Id }, document);
    }

    [HttpPatch()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Core.Services.Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(int id, [FromBody] PlanTrabajoPuntoUpsert rowUpsert)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(PostAsync)}");
            return BadRequest(ModelState);
        }

        var document = await _unitOfWork.PlanesTrabajosPuntos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        document.IdPlanTrabajo = rowUpsert.IdPlanTrabajo;
        document.Descripcion = rowUpsert.Descripcion;
        document.TipoPunto = rowUpsert.TipoPunto;
        document.Activo = rowUpsert.Activo;

        _unitOfWork.PlanesTrabajosPuntos.Update(document);
        await _unitOfWork.Save();

        return Ok(document); //return CreatedAtRoute("GetOneAsync", new { id = document.Id }, document);
    }

    [HttpPut()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Core.Services.Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] PlanTrabajoPuntoUpsert rowUpsert)
    {
        if (!ModelState.IsValid || id < 1)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest(ModelState);
        }


        var document = await _unitOfWork.PlanesTrabajosPuntos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        _mapper.Map(rowUpsert, document);
        _unitOfWork.PlanesTrabajosPuntos.Update(document);
        await _unitOfWork.Save();

        return Ok();
    }

    [HttpPatch()]
    [Route("active/{id:int}")]
    [ProducesResponseType(typeof(Core.Services.Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        if (id < 1)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAsync)}");
            return BadRequest();
        }

        var document = await _unitOfWork.PlanesTrabajosPuntos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        document.Activo = false;
        _unitOfWork.PlanesTrabajosPuntos.Update(document);
        await _unitOfWork.Save();

        return Ok();
    }

    [HttpDelete()]
    [Route("/hard/{id:int}")]
    [ProducesResponseType(typeof(Core.Services.Response<PlanTrabajoPunto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteHardAsync(int id)
    {
        if (id < 1)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHardAsync)}");
            return BadRequest();
        }

        var document = await _unitOfWork.PlanesTrabajosPuntos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHardAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        await _unitOfWork.PlanesTrabajosPuntos.Delete(id);
        await _unitOfWork.Save();

        return Ok();
    }
}