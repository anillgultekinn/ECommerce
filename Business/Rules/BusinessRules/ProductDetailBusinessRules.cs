using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ProductDetailBusinessRules : BaseBusinessRules
{
    private readonly IProductDetailDal _productDetailDal;

    public ProductDetailBusinessRules(IProductDetailDal productDetailDal)
    {
        _productDetailDal = productDetailDal;
    }

    public async Task IExistProductDetail(Guid productDetailId) 
    {
        var result = await _productDetailDal.GetAsync(
            predicate: p => p.Id == productDetailId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
