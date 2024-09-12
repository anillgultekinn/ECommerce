using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class BrandBusinessRules : BaseBusinessRules
{
    private readonly IBrandDal _brandDal;

    public BrandBusinessRules(IBrandDal brandDal)
    {
        _brandDal = brandDal;
    }

    public async Task IsExistsBrand(Guid brandId)
    {
        var result = await _brandDal.GetAsync(
            predicate: c => c.Id == brandId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
