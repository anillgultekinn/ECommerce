using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfProductDetailDal : EfRepositoryBase<ProductDetail, Guid, ECommerceContext>, IProductDetailDal
{
    public EfProductDetailDal(ECommerceContext context) : base(context)
    {
    }
}
