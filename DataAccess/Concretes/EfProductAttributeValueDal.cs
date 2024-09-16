using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfProductAttributeValueDal : EfRepositoryBase<ProductAttributeValue, Guid, ECommerceContext>, IProductAttributeValueDal
{
    public EfProductAttributeValueDal(ECommerceContext context) : base(context)
    {
    }
}
