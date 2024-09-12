using Business.Abstracts;
using Business.Dtos.Requests.GenderRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GendersController : ControllerBase
{
    IGenderService _genderService;

    public GendersController(IGenderService genderService)
    {
        _genderService = genderService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _genderService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _genderService.GetByIdAsync(id);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Genders.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateGenderRequest createGenderRequest)
    {
        var result = await _genderService.AddAsync(createGenderRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Genders.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenderRequest updateGenderRequest)
    {
        var result = await _genderService.UpdateAsync(updateGenderRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Genders.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _genderService.DeleteAsync(id);
        return Ok(result);
    }

}
