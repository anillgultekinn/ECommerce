using Business.Abstracts;
using Business.Dtos.Requests.CityRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CitiesController : ControllerBase
{
    ICityService _cityService;

    public CitiesController(ICityService cityService)
    {
        _cityService = cityService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _cityService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _cityService.GetByIdAsync(id);
        return Ok(result);
    }  


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Cities.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateCityRequest createCityRequest)
    {
        var result = await _cityService.AddAsync(createCityRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Cities.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateCityRequest updateCityRequest)
    {
        var result = await _cityService.UpdateAsync(updateCityRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Cities.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _cityService.DeleteAsync(id);
        return Ok(result);
    }   
}