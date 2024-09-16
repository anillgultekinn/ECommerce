using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands").HasKey(a => a.Id);

        builder.Property(a => a.Id).HasColumnName("Id").IsRequired();
        builder.Property(a => a.Name).HasColumnName("Name").IsRequired();

        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: a => a.Name, name: "UK_Name").IsUnique();


        builder.HasMany(b => b.Products)
                 .WithOne(p => p.Brand) // Brand ile Product arasında ilişki
                 .HasForeignKey(p => p.BrandId); // Product'ta BrandId anahtar alanı olacak


        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
