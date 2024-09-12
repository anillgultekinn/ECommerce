using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfDistrictDal : EfRepositoryBase<District, Guid, ECommerceContext>, IDistrictDal
{
    public EfDistrictDal(ECommerceContext context) : base(context)
    {
    }
}
