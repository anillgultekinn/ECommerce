using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IProductAttributeValueDal : IRepository<ProductAttributeValue, Guid>, IAsyncRepository<ProductAttributeValue, Guid>
{
}
