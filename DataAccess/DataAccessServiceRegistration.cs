using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ECommerceContext>(options => options.UseSqlServer(configuration.GetConnectionString("ECommerce")));


        services.AddScoped<IAccountDal, EfAccountDal>();
        services.AddScoped<IAddressDal, EfAddressDal>();
        services.AddScoped<IBrandDal, EfBrandDal>();
        services.AddScoped<ICategoryDal, EfCategoryDal>();
        services.AddScoped<ICityDal, EfCityDal>();
        services.AddScoped<IColorDal, EfColorDal>();
        services.AddScoped<ICountryDal, EfCountryDal>();
        services.AddScoped<IDistrictDal, EfDistrictDal>();
        services.AddScoped<IOperationClaimDal, EfOperationClaimDal>();
        services.AddScoped<IProductAttributeDal, EfProductAttributeDal>();
        services.AddScoped<IProductAttributeValueDal, EfProductAttributeValueDal>();
        services.AddScoped<IProductDal, EfProductDal>();
        services.AddScoped<IProductDetailDal, EfProductDetailDal>();
        services.AddScoped<IProductImageDal, EfProductImageDal>();
        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IUserOperationClaimDal, EfUserOperationClaimDal>();

        return services;
    }
}