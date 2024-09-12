using Core.DataAccess.Repositories;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class EfOperationClaimDal : EfRepositoryBase<OperationClaim, Guid, ECommerceContext>, IOperationClaimDal
{
    public EfOperationClaimDal(ECommerceContext context) : base(context)
    {
    }
}

