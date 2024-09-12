using Business.Abstracts;
using Business.Dtos.Requests.BrandRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandsController : ControllerBase
{
    IBrandService _brandService;

    public BrandsController(IBrandService brandService)
    {
        _brandService = brandService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _brandService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid Id)
    {
        var result = await _brandService.GetByIdAsync(Id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Brands.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateBrandRequest createBrandRequest)
    {
        var result = await _brandService.AddAsync(createBrandRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Brands.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateBrandRequest updateBrandRequest)
    {
        var result = await _brandService.UpdateAsync(updateBrandRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Brands.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _brandService.DeleteAsync(id);
        return Ok(result);
    }

}
