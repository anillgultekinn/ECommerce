using Business.Abstracts;
using Business.Concrete;
using Business.Concretes;
using Core.Business.Rules;
using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<IBrandService, BrandManager>();
        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<IColorService, ColorManager>();
        services.AddScoped<ICountryService, CountryManager>();
        services.AddScoped<IDistrictService, DistrictManager>();
        services.AddScoped<IGenderService, GenderManager>();
        services.AddScoped<IOperationClaimService, OperationClaimManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<ISizeService, SizeManager>();
        services.AddScoped<IUserOperationClaimService, UserOperationClaimManager>();
        services.AddScoped<IUserService, UserManager>();


        services.AddScoped<IOperationClaimService, OperationClaimManager>();




        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
        return services;

    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
}