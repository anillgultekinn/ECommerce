using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.ToTable("Genders").HasKey(c => c.Id);

        builder.Property(g => g.Id).HasColumnName("Id").IsRequired();
        builder.Property(g => g.Name).HasColumnName("Name").IsRequired();

        builder.HasIndex(indexExpression: g => g.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: g => g.Name, name: "UK_Name").IsUnique();



        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
