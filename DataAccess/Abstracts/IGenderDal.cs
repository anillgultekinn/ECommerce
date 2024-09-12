using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IGenderDal : IRepository<Gender, Guid>, IAsyncRepository<Gender, Guid>
{
}
