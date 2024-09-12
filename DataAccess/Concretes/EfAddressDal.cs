using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfAddressDal : EfRepositoryBase<Address, Guid, ECommerceContext>, IAddressDal
{
    public EfAddressDal(ECommerceContext context) : base(context)
    {
    }
}
