using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
{
    public void Configure(EntityTypeBuilder<ProductDetail> builder)
    {
        builder.ToTable("ProductDetails").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(p => p.ProductAttributeId).HasColumnName("ProductAttributeId").IsRequired();
        builder.Property(p => p.Value).HasColumnName("Value").IsRequired();
        builder.Property(p => p.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        builder.Property(p => p.UnitsInStock).HasColumnName("UnitsInStock").IsRequired();


        builder.HasOne(p => p.Product);
        builder.HasOne(p => p.ProductAttribute);      

        builder.HasQueryFilter(op => !op.DeletedDate.HasValue);

    }
}
