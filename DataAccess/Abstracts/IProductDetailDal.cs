using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IProductDetailDal : IRepository<ProductDetail, Guid>, IAsyncRepository<ProductDetail, Guid>
{
}
