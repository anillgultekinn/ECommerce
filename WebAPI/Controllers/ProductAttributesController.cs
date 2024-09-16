using Business.Abstracts;
using Business.Dtos.Requests.ProductRequests;
using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog.Logger;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.Paging;
using Microsoft.AspNetCore.Mvc;
using Business.Dtos.Requests.ProductAttributeRequests;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductAttributesController : ControllerBase
{
    IProductAttributeService _productAttributeService;

    public ProductAttributesController(IProductAttributeService productAttributeService)
    {
        _productAttributeService = productAttributeService;
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache(60)]
    [HttpGet("GetList")]
    public async Task<IActionResult> GetListAsync([FromQuery] PageRequest pageRequest)
    {
        var result = await _productAttributeService.GetListAsync(pageRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [Cache]
    [HttpGet("GetById")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        var result = await _productAttributeService.GetByIdAsync(id);
        return Ok(result);
    }



    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductAttributes.Get")]
    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] CreateProductAttributeRequest createProductAttributeRequest)
    {
        var result = await _productAttributeService.AddAsync(createProductAttributeRequest);
        return Ok(result);
    }


    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductAttributes.Get")]
    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateProductAttributeRequest updateProductAttributeRequest)
    {
        var result = await _productAttributeService.UpdateAsync(updateProductAttributeRequest);
        return Ok(result);
    }

    [Logging(typeof(MsSqlLogger))]
    [Logging(typeof(FileLogger))]
    [CacheRemove("ProductAttributes.Get")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
    {
        var result = await _productAttributeService.DeleteAsync(id);
        return Ok(result);
    }
}
