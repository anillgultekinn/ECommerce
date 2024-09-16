using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
{
    public void Configure(EntityTypeBuilder<ProductAttribute> builder)
    {
        builder.ToTable("ProductAttributes").HasKey(p => p.Id);

        builder.Property(pa => pa.Id).HasColumnName("Id").IsRequired();
        builder.Property(pa => pa.Name).HasColumnName("Name").IsRequired();


        builder.HasIndex(indexExpression: pa => pa.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: pa => pa.Name, name: "UK_Name").IsUnique();

        builder.HasQueryFilter(op => !op.DeletedDate.HasValue);
    }
}
