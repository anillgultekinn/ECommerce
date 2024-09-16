using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(p => p.CategoryId).HasColumnName("CategoryId").IsRequired();
        builder.Property(p => p.Title).HasColumnName("Title").IsRequired();
        builder.Property(p => p.Description).HasColumnName("Description").IsRequired();


        builder.HasMany(p => p.ProductDetails)
            .WithOne(pd => pd.Product)
            .HasForeignKey(pd => pd.ProductId);


        builder.HasMany(p => p.ProductImages)
            .WithOne(pd => pd.Product)
            .HasForeignKey(pd => pd.ProductId);

        builder.HasOne(p => p.Category);
        builder.HasOne(p => p.Brand);

        builder.HasQueryFilter(op => !op.DeletedDate.HasValue);
    }
}
