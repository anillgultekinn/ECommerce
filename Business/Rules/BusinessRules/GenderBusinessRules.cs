using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class GenderBusinessRules : BaseBusinessRules
{
    private readonly IGenderDal _genderDal;

    public GenderBusinessRules(IGenderDal genderDal)
    {
        _genderDal = genderDal;
    }

    public async Task IsExistsGender(Guid genderId)
    {
        var result = await _genderDal.GetAsync(
            predicate: c => c.Id == genderId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
