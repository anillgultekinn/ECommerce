using Business.Abstracts;
using Business.Dtos.Requests.ProductDetailRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductDetailsController : ControllerBase
{
    IProductDetailService _productDetailService;

    public ProductDetailsController(IProductDetailService productDetailService)
    {
        _productDetailService = productDetailService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _productDetailService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _productDetailService.GetByIdAsync(id);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductDetails.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateProductDetailRequest createProductDetailRequest)
    {
        var result = await _productDetailService.AddAsync(createProductDetailRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductDetails.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductDetailRequest updateProductDetailRequest)
    {
        var result = await _productDetailService.UpdateAsync(updateProductDetailRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductDetails.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _productDetailService.DeleteAsync(id);
        return Ok(result);
    }
}
