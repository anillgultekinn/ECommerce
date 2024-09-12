using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCityDal : EfRepositoryBase<City, Guid, ECommerceContext>, ICityDal
{
    public EfCityDal(ECommerceContext context) : base(context)
    {
    }
}
