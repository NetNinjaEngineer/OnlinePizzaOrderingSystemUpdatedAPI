using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Enums;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.OrderTime)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.OrderTime)
                .HasColumnType("time")
                .IsRequired();

            builder.Property(x => x.TotalCost)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.CustomerId)
                .IsRequired();

            builder.HasOne(x => x.DeliveryDriver)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.DeliveryDriverId)
                .IsRequired();

            builder.Property(x => x.DeliveryOptions)
                .HasConversion(
                    x => x.ToString(),
                    x => (DeliveryOptions)Enum.Parse(typeof(DeliveryOptions), x)
                );

            builder.ToTable("Orders");

            builder.HasData(GetOrders());
        }

        private static List<Order> GetOrders()
        {
            return new List<Order>()
            {
                new Order { Id = 1, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 50.0m, DeliveryOptions = DeliveryOptions.Standard, CustomerId = 1, DeliveryDriverId = 1 },
                new Order { Id = 2, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 25.0m, DeliveryOptions = DeliveryOptions.InStorePickup, DeliveryDriverId = 1, CustomerId = 2 },
                new Order { Id = 3, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 75.0m, DeliveryOptions = DeliveryOptions.WhiteGlove, CustomerId = 2, DeliveryDriverId = 3 },
                new Order { Id = 4, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 100.0m, DeliveryOptions = DeliveryOptions.WhiteGlove, DeliveryDriverId = 2, CustomerId = 4 },
                new Order { Id = 5, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 60.0m, DeliveryOptions = DeliveryOptions.InStorePickup, CustomerId = 3, DeliveryDriverId = 5},
                new Order { Id = 6, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 80.0m, DeliveryOptions = DeliveryOptions.InStorePickup, DeliveryDriverId = 3, CustomerId = 6 },
                new Order { Id = 7, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 30.0m, DeliveryOptions = DeliveryOptions.Standard, CustomerId = 4 , DeliveryDriverId = 7},
                new Order { Id = 8, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 90.0m, DeliveryOptions = DeliveryOptions.Express, CustomerId = 5 , DeliveryDriverId = 8},
                new Order { Id = 9, OrderDate = DateTime.Now.Date, OrderTime =  TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 120.0m, DeliveryOptions = DeliveryOptions.CurbsidePickup, DeliveryDriverId = 4, CustomerId = 9 },
                new Order { Id = 10, OrderDate = DateTime.Now.Date, OrderTime = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 70.0m, DeliveryOptions = DeliveryOptions.Express, CustomerId = 6, DeliveryDriverId = 9 },
                new Order { Id = 11, OrderDate = DateTime.Now.Date, OrderTime = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 50.0m, DeliveryOptions = DeliveryOptions.CurbsidePickup, CustomerId = 7, DeliveryDriverId = 2 },
                new Order { Id = 12, OrderDate = DateTime.Now.Date, OrderTime = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 25.0m, DeliveryOptions = DeliveryOptions.Express, DeliveryDriverId = 5, CustomerId =12 },
                new Order { Id = 13, OrderDate = DateTime.Now.Date, OrderTime = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 75.0m, DeliveryOptions = DeliveryOptions.WhiteGlove, CustomerId = 8 , DeliveryDriverId = 1},
                new Order { Id = 14, OrderDate = DateTime.Now.Date, OrderTime = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 100.0m, DeliveryOptions = DeliveryOptions.WhiteGlove, DeliveryDriverId = 6, CustomerId = 14 },
                new Order { Id = 15, OrderDate = DateTime.Now.Date, OrderTime = TimeSpan.Parse(DateTime.Now.TimeOfDay.ToString()), TotalCost = 60.0m, DeliveryOptions = DeliveryOptions.Standard, CustomerId = 9, DeliveryDriverId = 3 },
            };
        }
    }
}