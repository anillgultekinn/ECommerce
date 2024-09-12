using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfProductDal : EfRepositoryBase<Product, Guid, ECommerceContext>, IProductDal
{
    public EfProductDal(ECommerceContext context) : base(context)
    {
    }
}
