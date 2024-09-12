using Business.Abstracts;
using Business.Dtos.Requests.SizeRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SizesController : ControllerBase
{
    ISizeService _sizeService;

    public SizesController(ISizeService sizeService)
    {
        _sizeService = sizeService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _sizeService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _sizeService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Sizes.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateSizeRequest createSizeRequest)
    {
        var result = await _sizeService.AddAsync(createSizeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Sizes.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateSizeRequest updateSizeRequest)
    {
        var result = await _sizeService.UpdateAsync(updateSizeRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Sizes.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _sizeService.DeleteAsync(id);
        return Ok(result);
    }
}
