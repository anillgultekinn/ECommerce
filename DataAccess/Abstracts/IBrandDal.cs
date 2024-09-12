using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IBrandDal : IRepository<Brand, Guid>, IAsyncRepository<Brand, Guid>
{
}
