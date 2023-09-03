using Core.Entities.OrderAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Order owns ShipToAddress. a is the related entity
            builder.OwnsOne(o => o.ShipToAddress, a =>
            {
                a.WithOwner();
                // We'll rely on our AddressDto to handle our valdiation, but we should probably do so as well here
            });

            // We want to turn our enum into a string rather than the default enum behavior
            builder.Property(s => s.Status)
                .HasConversion(
                    o => o.ToString(),
                    o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                );

            // If we delete an order, we also want to delete all order items
            builder.HasMany(o => o.OrderItems).WithOne().OnDelete(DeleteBehavior.Cascade);
        }
    }
}