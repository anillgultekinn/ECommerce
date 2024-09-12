using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ProductBusinessRules : BaseBusinessRules
{
    private readonly IProductDal _productDal;

    public ProductBusinessRules(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public async Task IExistProduct(Guid productId)
    {
        var result = await _productDal.GetAsync(
            predicate: p => p.Id == productId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
