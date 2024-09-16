using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ProductAttributeBusinessRules : BaseBusinessRules
{
    private readonly IProductAttributeDal _productAttributeDal;

    public ProductAttributeBusinessRules(IProductAttributeDal productAttributeDal)
    {
        _productAttributeDal = productAttributeDal;
    }

    public async Task IExistProductAttribute(Guid productAttributeId)
    {
        var result = await _productAttributeDal.GetAsync(
            predicate: p => p.Id == productAttributeId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
