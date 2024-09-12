using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface ISizeDal : IRepository<Size, Guid>, IAsyncRepository<Size, Guid>
{
}
