using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfBrandDal : EfRepositoryBase<Brand, Guid, ECommerceContext>, IBrandDal
{
    public EfBrandDal(ECommerceContext context) : base(context)
    {
    }
}
