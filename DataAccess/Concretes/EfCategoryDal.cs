using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfCategoryDal : EfRepositoryBase<Category, Guid, ECommerceContext>, ICategoryDal
{
    public EfCategoryDal(ECommerceContext context) : base(context)
    {
    }
}
