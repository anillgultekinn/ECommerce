using Core.Entities;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace DataAccess.Contexts;

public class ECommerceContext : DbContext
{
    protected IConfiguration Configuration { get; set; }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<City> Cities{ get; set; }
    public DbSet<Color> Colors { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<District> Districts { get; set; }
    public DbSet<Gender> Genders{ get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<Product> Products{ get; set; }
    public DbSet<Size> Sizes{ get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }


    public ECommerceContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}