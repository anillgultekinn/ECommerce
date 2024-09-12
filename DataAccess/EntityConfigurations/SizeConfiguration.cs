using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class SizeConfiguration : IEntityTypeConfiguration<Size>
{
    public void Configure(EntityTypeBuilder<Size> builder)
    {
        builder.ToTable("Sizes").HasKey(c => c.Id);

        builder.Property(s => s.Id).HasColumnName("Id").IsRequired();
        builder.Property(s => s.Name).HasColumnName("Name").IsRequired();

        builder.HasIndex(indexExpression: s => s.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: s => s.Name, name: "UK_Name").IsUnique();



        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
