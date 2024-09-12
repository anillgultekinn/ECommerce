using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.BusinessRules
{
    public class SizeBusinessRules : BaseBusinessRules
    {
        private readonly ISizeDal _sizeDal;

        public SizeBusinessRules(ISizeDal sizeDal)
        {
            _sizeDal = sizeDal;
        }

        public async Task IsExistsSize(Guid sizeId)
        {
            var result = await _sizeDal.GetAsync(
                predicate: s => s.Id == sizeId,
                enableTracking: false);

            if (result == null)
            {
                throw new BusinessException(BusinessMessages.DataNotFound);
            }
        }
    }
}
