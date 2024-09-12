using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfColorDal : EfRepositoryBase<Color, Guid, ECommerceContext>, IColorDal
{
    public EfColorDal(ECommerceContext context) : base(context)
    {
    }
}
