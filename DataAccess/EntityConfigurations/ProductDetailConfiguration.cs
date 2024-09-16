using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductDetailConfiguration : IEntityTypeConfiguration<ProductDetail>
{
    public void Configure(EntityTypeBuilder<ProductDetail> builder)
    {
        builder.ToTable("ProductDetails").HasKey(p => p.Id);

        builder.Property(pd => pd.Id).HasColumnName("Id").IsRequired();
        builder.Property(pd => pd.ProductId).HasColumnName("ProductId").IsRequired();
        builder.Property(pd => pd.UnitPrice).HasColumnName("UnitPrice").IsRequired();
        builder.Property(pd => pd.UnitsInStock).HasColumnName("UnitsInStock").IsRequired();


        builder.HasOne(pd => pd.Product);

        builder.HasMany(pd => pd.ProductAttributeValues)
            .WithOne(pd => pd.ProductDetail)
            .HasForeignKey(pd => pd.ProductDetailId);

        builder.HasQueryFilter(op => !op.DeletedDate.HasValue);

    }
}
