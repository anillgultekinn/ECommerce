using Business.Abstracts;
using Business.Dtos.Requests.ProductAttributeValueRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductAttributeValuesController : ControllerBase
{
    IProductAttributeValueService _productAttributeValueService;

    public ProductAttributeValuesController(IProductAttributeValueService productAttributeValueService)
    {
        _productAttributeValueService = productAttributeValueService;
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _productAttributeValueService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _productAttributeValueService.GetByIdAsync(id);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductAttributeValues.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateProductAttributeValueRequest createProductAttributeValueRequest)
    {
        var result = await _productAttributeValueService.AddAsync(createProductAttributeValueRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductAttributeValues.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductAttributeValueRequest updateProductAttributeValueRequest)
    {
        var result = await _productAttributeValueService.UpdateAsync(updateProductAttributeValueRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductAttributeValues.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _productAttributeValueService.DeleteAsync(id);
        return Ok(result);
    }
}