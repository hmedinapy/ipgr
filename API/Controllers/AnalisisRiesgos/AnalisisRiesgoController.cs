using API.Core.DTOs;
using API.Core.Models;
using API.Core.Repository;
using API.Data.Entities;
using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.AnalisisRiesgos;

[ApiController]
[Route("[controller]")]
public class AnalisisRiesgoController : ControllerBase
{
    private readonly ILogger<AnalisisRiesgoController> _logger;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AnalisisRiesgoController(ILogger<AnalisisRiesgoController> logger, IUnitOfWork _unitOfWork, IMapper mapper)
    {
        _logger = logger;
        this._unitOfWork = _unitOfWork;
        _mapper = mapper;
    }

    [HttpGet()]
    //[ProducesResponseType(typeof(Response<List<AnalisisRiesgo>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetAllAsync([FromQuery] RequestParams requestParams)
    {
        var documents = await _unitOfWork.AnalisisRiesgos.GetPagedList(requestParams);
        var results = _mapper.Map<IList<AnalisisRiesgoDTO>>(documents);
        return Ok(results);
    }

    [Authorize(Roles = "Administrador")]
    [HttpGet()]
    [Route("{id:int}")]
    //[ProducesResponseType(typeof(Response<List<AnalisisRiesgo>>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> GetOneAsync(int id)
    {
        var document = await _unitOfWork.AnalisisRiesgos.Get(q => q.Id == id, 
            include: q => q.Include(x => x.IdAreaNavigation)
            );
        var result = _mapper.Map<AnalisisRiesgoDTO>(document);
        return Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PostAsync([FromBody] AnalisisRiesgoUpsert rowUpsert)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(PostAsync)}");
            return BadRequest(ModelState);
        }

        var document = _mapper.Map<AnalisisRiesgo>(rowUpsert);
        await _unitOfWork.AnalisisRiesgos.Insert(document);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetOneAsync", new { id = document.Id }, document);
    }

    [HttpPatch()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> PatchAsync(int id, [FromBody] AnalisisRiesgoUpsert rowUpsert)
    {
        if (!ModelState.IsValid)
        {
            _logger.LogError($"Invalid POST attempt in {nameof(PostAsync)}");
            return BadRequest(ModelState);
        }

        var document = await _unitOfWork.AnalisisRiesgos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest("Submitted data is invalid");
        }


        document.IdArea = rowUpsert.IdArea;
        document.IdRiesgo = rowUpsert.IdRiesgo;
        document.Significado = rowUpsert.Significado;
        document.AgenteGenerador = rowUpsert.AgenteGenerador;
        document.Causa = rowUpsert.Causa;
        document.Efecto = rowUpsert.Efecto;
        document.Probabilidad = rowUpsert.Probabilidad;
        document.Impacto = rowUpsert.Impacto;
        document.Resultado = rowUpsert.Resultado;
        document.NivelRiesgo = rowUpsert.NivelRiesgo;

        _unitOfWork.AnalisisRiesgos.Update(document);
        await _unitOfWork.Save();

        return CreatedAtRoute("GetOneAsync", new { id = document.Id }, document);
    }

    [HttpPut()]
    [Route("{id:int}")]
    [ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> PutAsync(int id, [FromBody] AnalisisRiesgoUpsert rowUpsert)
    {
        if (!ModelState.IsValid || id < 1)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest(ModelState);
        }


        var document = await _unitOfWork.AnalisisRiesgos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid UPDATE attempt in {nameof(PutAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        _mapper.Map(rowUpsert, document);
        _unitOfWork.AnalisisRiesgos.Update(document);
        await _unitOfWork.Save();

        return Ok();
    }

    [HttpPatch()]
    [Route("active/{id:int}")]
    [ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        if (id < 1)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAsync)}");
            return BadRequest();
        }

        var document = await _unitOfWork.AnalisisRiesgos.Get(q => q.Id == id);
        if (document == null)
        {
            _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteAsync)}");
            return BadRequest("Submitted data is invalid");
        }

        document.Activo = false;
        _unitOfWork.AnalisisRiesgos.Update(document);
        await _unitOfWork.Save();

        return Ok();
    }

    //[HttpDelete()]
    //[Route("hard/{id:int}")]
    //[ProducesResponseType(typeof(Response<AnalisisRiesgo>), StatusCodes.Status200OK)]
    //[ProducesResponseType(StatusCodes.Status204NoContent)]
    //public async Task<ActionResult> DeleteHardAsync(int id)
    //{
    //    if (id < 1)
    //    {
    //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHardAsync)}");
    //        return BadRequest();
    //    }

    //    var document = await _unitOfWork.AnalisisRiesgos.Get(q => q.Id == id);
    //    if (document == null)
    //    {
    //        _logger.LogError($"Invalid DELETE attempt in {nameof(DeleteHardAsync)}");
    //        return BadRequest("Submitted data is invalid");
    //    }

    //    await _unitOfWork.AnalisisRiesgos.Delete(id);
    //    await _unitOfWork.Save();

    //    return Ok();
    //}
}