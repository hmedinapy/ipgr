using API.Core.DTOs;
using API.Core.Models;
using API.Core.Repository;
using API.Core.Services;
using API.Data.Entities;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Riesgos;

[ApiController]
[Route("[controller]")]
public class RiesgoController : ControllerBase
{
    private readonly ILogger<RiesgoController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RiesgoController(ILogger<RiesgoController> logger, IUnitOfWork _unitOfWork, IMapper mapper)
    {
        _logger = logger;
        this._unitOfWork = _unitOfWork;
        _mapper = mapper;
    }

    [HttpGet()]
    //[ProducesResponseType(typeof(Core.Services.Response<List<Riesgo>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync([FromQuery] RequestParams requestParams)
    {
        var documents = await _unitOfWork.Riesgos.GetPagedList(requestParams);
        if (documents.Count == 0)
            return NoContent();

        var results = _mapper.Map<IList<RiesgoDTO>>(documents);
        return Ok(results);
    }

    //[Authorize(Roles = "Administrador")]
    [HttpGet()]
    [Route("{id:int}")]
    //[ProducesResponseType(typeof(Core.Services.Response<List<Riesgo>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await _unitOfWork.Riesgos.Get(q => q.Id == id);
        if (document == null)
            return NoContent();

        var result = _mapper.Map<RiesgoDTO>(document);
        return Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Core.Services.Response<Riesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync([FromBody] RiesgoUpsert rowUpsert)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(PostAsync)}");
            return BadRequest(ModelState);
        }

        var document = _mapper.Map<Riesgo>(rowUpsert);
        await _unitOfWork.Riesgos.Insert(document);
        await _unitOfWork.Save();

        return Ok(document); //return CreatedAtRoute("GetOneAsync", new { id = document.Id }, document);
    }

    [HttpPatch()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Core.Services.Response<Riesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(int id, [FromBody] RiesgoUpsert rowUpsert)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(PostAsync)}");
            return BadRequest(ModelState);
        }

        var document = await _unitOfWork.Riesgos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        document.Descripcion = rowUpsert.Descripcion;

        _unitOfWork.Riesgos.Update(document);
        await _unitOfWork.Save();

        return Ok(document); //return CreatedAtRoute("GetOneAsync", new { id = document.Id }, document);
    }

    [HttpPut()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Core.Services.Response<Riesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] RiesgoUpsert rowUpsert)
    {
        if (!ModelState.IsValid || id < 1)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest(ModelState);
        }


        var document = await _unitOfWork.Riesgos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        _mapper.Map(rowUpsert, document);
        _unitOfWork.Riesgos.Update(document);
        await _unitOfWork.Save();

        return Ok();
    }

    [HttpPatch()]
    [Route("active/{id:int}")]
    [ProducesResponseType(typeof(Core.Services.Response<Riesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        if (id < 1)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAsync)}");
            return BadRequest();
        }

        var document = await _unitOfWork.Riesgos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        document.Activo = false;
        _unitOfWork.Riesgos.Update(document);
        await _unitOfWork.Save();

        return Ok();
    }

    //[HttpDelete()]
    //[Route("/hard/{id:int}")]
    //[ProducesResponseType(typeof(Core.Services.Response<Riesgo>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //public async Task<ActionResult> DeleteHardAsync(int id)
    //{
    //    if (id < 1)
    //    {
    //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHardAsync)}");
    //        return BadRequest();
    //    }

    //    var document = await _unitOfWork.Riesgos.Get(q => q.Id == id);
    //    if (document == null)
    //    {
    //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHardAsync)}");
    //        return BadRequest("Submitted data is invalid");
    //    }

    //    await _unitOfWork.Riesgos.Delete(id);
    //    await _unitOfWork.Save();

    //    return Ok();
    //}
}