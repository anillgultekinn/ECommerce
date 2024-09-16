using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IProductImageDal : IRepository<ProductImage, Guid>, IAsyncRepository<ProductImage, Guid>
{
}
