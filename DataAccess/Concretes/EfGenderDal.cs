using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes;

public class EfGenderDal : EfRepositoryBase<Gender, Guid, ECommerceContext>, IGenderDal
{
    public EfGenderDal(ECommerceContext context) : base(context)
    {
    }
}
