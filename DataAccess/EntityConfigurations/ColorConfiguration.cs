using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("Colors").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();

        builder.HasIndex(indexExpression: c => c.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: c => c.Name, name: "UK_Name").IsUnique();

        builder.HasMany(c => c.Products);


        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
