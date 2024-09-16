using Business.Abstracts;
using Business.Dtos.Requests.ProductImageRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductImagesController : ControllerBase
{
    IProductImageService _productImageService;

    public ProductImagesController(IProductImageService ProductImageService)
    {
        _productImageService = ProductImageService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _productImageService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _productImageService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductImages.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateProductImageRequest createProductImageRequest)
    {
        var result = await _productImageService.AddAsync(createProductImageRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductImages.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductImageRequest updateProductImageRequest)
    {
        var result = await _productImageService.UpdateAsync(updateProductImageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductImages.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _productImageService.DeleteAsync(id);
        return Ok(result);
    }
}