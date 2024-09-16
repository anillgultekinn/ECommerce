using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ProductAttributeValueBusinessRules : BaseBusinessRules
{
    private readonly IProductAttributeValueDal _productAttributeValueDal;

    public ProductAttributeValueBusinessRules(IProductAttributeValueDal productAttributeValueDal)
    {
        _productAttributeValueDal = productAttributeValueDal;
    }

    public async Task IExistProductAttributeValue(Guid productAttributeValueId)
    {
        var result = await _productAttributeValueDal.GetAsync(
            predicate: p => p.Id == productAttributeValueId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
