using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductAttributeValueConfiguration : IEntityTypeConfiguration<ProductAttributeValue>
{
    public void Configure(EntityTypeBuilder<ProductAttributeValue> builder)
    {
        builder.ToTable("ProductAttributeValues").HasKey(p => p.Id);

        builder.Property(pav => pav.Id).HasColumnName("Id").IsRequired();
        builder.Property(pav => pav.ProductDetailId).HasColumnName("ProductDetailId").IsRequired();
        builder.Property(pav => pav.ProductAttributeId).HasColumnName("ProductAttributeId").IsRequired();

        builder.HasQueryFilter(pav => !pav.DeletedDate.HasValue);

        builder.HasOne(pav => pav.ProductDetail);
        builder.HasOne(pav => pav.ProductAttribute);
    }
}
