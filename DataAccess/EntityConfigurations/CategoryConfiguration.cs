using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.EntityConfigurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
        builder.Property(c => c.ParentId).HasColumnName("ParentId");

        builder.HasIndex(indexExpression: a => a.Id, name: "UK_Id").IsUnique();
        builder.HasIndex(indexExpression: a => a.Name, name: "UK_Name").IsUnique();

        builder.HasOne(c => c.Parent)
                   .WithMany() // Çocukları belirtmeyin, sadece Parent ile ilişkili
                   .HasForeignKey(c => c.ParentId)
                   .OnDelete(DeleteBehavior.Restrict); // Kategori silindiğinde, alt kategoriler etkilenmez

        builder.HasQueryFilter(a => !a.DeletedDate.HasValue);
    }
}
