using Business.Abstracts;
using Business.Dtos.Requests.ColorRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorsController : ControllerBase
{
    IColorService _colorService;

    public ColorsController(IColorService colorService)
    {
        _colorService = colorService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _colorService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _colorService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Colors.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateColorRequest createColorRequest)
    {
        var result = await _colorService.AddAsync(createColorRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Colors.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateColorRequest updateColorRequest)
    {
        var result = await _colorService.UpdateAsync(updateColorRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Colors.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _colorService.DeleteAsync(id);
        return Ok(result);
    }
}
