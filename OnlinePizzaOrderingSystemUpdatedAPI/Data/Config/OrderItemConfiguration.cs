using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Price).HasPrecision(15, 2).IsRequired();

            builder.HasOne(x => x.Order)
                    .WithMany(x => x.OrderItems)
                    .HasForeignKey(x => x.OrderId)
                    .IsRequired();

            builder.ToTable("OrderItems");
            builder.HasData(GetOrderItems());
        }

        private static List<OrderItem> GetOrderItems()
        {
            return new List<OrderItem>
            {
                new OrderItem { Id = 1, Quantity = 2, Price = 9.99m, OrderId = 1 },
                new OrderItem { Id = 2, Quantity = 1, Price = 11.99m, OrderId = 2 },
                new OrderItem { Id = 3, Quantity = 3, Price = 7.99m, OrderId = 3 },
                new OrderItem { Id = 4, Quantity = 2, Price = 12.99m, OrderId = 4 },
                new OrderItem { Id = 5, Quantity = 1, Price = 10.99m, OrderId = 5 },
                new OrderItem { Id = 6, Quantity = 2, Price = 13.99m, OrderId = 6 },
                new OrderItem { Id = 7, Quantity = 1, Price = 14.99m, OrderId = 7 },
                new OrderItem { Id = 8, Quantity = 3, Price = 11.99m, OrderId = 8 },
                new OrderItem { Id = 9, Quantity = 1, Price = 8.99m, OrderId = 9 },
                new OrderItem { Id = 10, Quantity = 2, Price = 15.99m, OrderId = 10 },
                new OrderItem { Id = 11, Quantity = 1, Price = 10.99m, OrderId = 11 },
                new OrderItem { Id = 12, Quantity = 3, Price = 9.99m, OrderId = 12 },
                new OrderItem { Id = 13, Quantity = 2, Price = 13.99m, OrderId = 13 },
                new OrderItem { Id = 14, Quantity = 1, Price = 10.99m, OrderId = 14 },
                new OrderItem { Id = 15, Quantity = 2, Price = 8.99m, OrderId = 15 }
            };
        }
    }
}
