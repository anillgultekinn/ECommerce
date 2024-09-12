using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IColorDal : IRepository<Color, Guid>, IAsyncRepository<Color, Guid>
{
}
