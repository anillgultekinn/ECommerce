using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class CategoryBusinessRules : BaseBusinessRules
{
    private readonly ICategoryDal _categoryDal;

    public CategoryBusinessRules(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public async Task IsExistsCategory(Guid categoryId)
    {
        var result = await _categoryDal.GetAsync(
            predicate: c => c.Id == categoryId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
