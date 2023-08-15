using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // we can access the specific properties of Product
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)"); // SQLite doesn't have support for decimals, so we do this..
            builder.Property(p => p.PictureUrl).IsRequired();
            builder.HasOne(b => b.ProductBrand).WithMany() // each product has a single brand that it's related to, but each brand can be associated with many products
                .HasForeignKey(p => p.ProductBrandId); // EF has already done this for us but we're doing it anyway
            builder.HasOne(t => t.ProductType).WithMany()
                .HasForeignKey(p => p.ProductTypeId);
        }
    }
}