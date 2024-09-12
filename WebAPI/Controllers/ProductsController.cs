using Business.Abstracts;
using Business.Dtos.Requests.ProductRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _productService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _productService.GetByIdAsync(id);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Products.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateProductRequest createProductRequest)
    {
        var result = await _productService.AddAsync(createProductRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Products.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductRequest updateProductRequest)
    {
        var result = await _productService.UpdateAsync(updateProductRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("Products.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _productService.DeleteAsync(id);
        return Ok(result);
    }
}
