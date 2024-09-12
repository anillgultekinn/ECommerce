using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCountryDal : EfRepositoryBase<Country, Guid, ECommerceContext>, ICountryDal
{
    public EfCountryDal(ECommerceContext context) : base(context)
    {
    }
}
