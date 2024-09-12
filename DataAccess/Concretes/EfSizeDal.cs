using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfSizeDal : EfRepositoryBase<Size, Guid, ECommerceContext>, ISizeDal
{
    public EfSizeDal(ECommerceContext context) : base(context)
    {
    }
}
