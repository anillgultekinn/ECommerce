using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;

namespace Business.Rules.BusinessRules;

public class ProductImageBusinessRules : BaseBusinessRules
{
    private readonly IProductImageDal _productImageDal;

    public ProductImageBusinessRules(IProductImageDal productImageDal)
    {
        _productImageDal = productImageDal;
    }
    public async Task IExistProductImage(Guid productImageId)
    {
        var result = await _productImageDal.GetAsync(
            predicate: p => p.Id == productImageId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
