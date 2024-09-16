using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfProductAttributeDal : EfRepositoryBase<ProductAttribute, Guid, ECommerceContext>, IProductAttributeDal
{
    public EfProductAttributeDal(ECommerceContext context) : base(context)
    {
    }
}
