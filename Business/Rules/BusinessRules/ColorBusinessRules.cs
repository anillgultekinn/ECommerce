using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ColorBusinessRules : BaseBusinessRules
{
    private readonly IColorDal _colorDal;

    public ColorBusinessRules(IColorDal colorDal)
    {
        _colorDal = colorDal;
    }

    public async Task IsExistsColor(Guid colorId)
    {
        var result = await _colorDal.GetAsync(
            predicate: c => c.Id == colorId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
