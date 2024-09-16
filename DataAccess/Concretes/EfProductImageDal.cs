using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfProductImageDal : EfRepositoryBase<ProductImage, Guid, ECommerceContext>, IProductImageDal
{
    public EfProductImageDal(ECommerceContext context) : base(context)
    {
    }
}
