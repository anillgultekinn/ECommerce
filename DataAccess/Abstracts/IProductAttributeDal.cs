using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IProductAttributeDal : IRepository<ProductAttribute, Guid>, IAsyncRepository<ProductAttribute, Guid>
{
}
