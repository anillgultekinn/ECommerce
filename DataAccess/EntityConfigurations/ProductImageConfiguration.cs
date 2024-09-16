using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
{
    public void Configure(EntityTypeBuilder<ProductImage> builder)
    {
        builder.ToTable("ProductImages").HasKey(pi => pi.Id);

        builder.Property(pi => pi.Id).HasColumnName("Id").IsRequired();
        builder.Property(pi => pi.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(pi => pi.ImageUrl).HasColumnName("ImageUrl").IsRequired();


        builder.HasQueryFilter(op => !op.DeletedDate.HasValue);

        builder.HasOne(pi => pi.Product);

    }
}
