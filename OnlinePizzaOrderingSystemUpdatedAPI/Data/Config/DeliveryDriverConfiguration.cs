using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class DeliveryDriverConfiguration : IEntityTypeConfiguration<DeliveryDriver>
    {
        public void Configure(EntityTypeBuilder<DeliveryDriver> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.PhoneNumber)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.VehicleInformation)
               .HasColumnType("VARCHAR")
               .HasMaxLength(250)
               .IsRequired();

            builder.HasOne(x => x.Store)
                .WithMany(x => x.DeliveryDrivers)
                .HasForeignKey(x => x.StoreId)
                .IsRequired();

            builder.ToTable("DeliveryDrivers");

            builder.HasData(GetDeliveryDrivers());
        }

        private static List<DeliveryDriver> GetDeliveryDrivers()
        {
            List<DeliveryDriver> drivers = new List<DeliveryDriver>()
            {
                new DeliveryDriver { Id = 1, Name = "John Smith", PhoneNumber = "555-1234", VehicleInformation = "2018 Honda Civic", StoreId = 1 },
                new DeliveryDriver { Id = 2, Name = "Jane Doe", PhoneNumber = "555-5678", VehicleInformation = "2020 Toyota Camry", StoreId = 2 },
                new DeliveryDriver { Id = 3, Name = "Bob Johnson", PhoneNumber = "555-9012", VehicleInformation = "2019 Ford F-150", StoreId = 3 },
                new DeliveryDriver { Id = 4, Name = "Sarah Lee", PhoneNumber = "555-3456", VehicleInformation = "2017 Nissan Altima", StoreId = 4 },
                new DeliveryDriver { Id = 5, Name = "David Kim", PhoneNumber = "555-7890", VehicleInformation = "2021 Honda Accord", StoreId = 5 },
                new DeliveryDriver { Id = 6, Name = "Maria Hernandez", PhoneNumber = "555-2345", VehicleInformation = "2016 Toyota Corolla", StoreId = 6 },
                new DeliveryDriver { Id = 7, Name = "Tom Wilson", PhoneNumber = "555-6789", VehicleInformation = "2017 Ford Escape", StoreId = 7 },
                new DeliveryDriver { Id = 8, Name = "Emily Chen", PhoneNumber = "555-0123", VehicleInformation = "2018 Honda CR-V", StoreId = 8 },
                new DeliveryDriver { Id = 9, Name = "Amy Nguyen", PhoneNumber = "555-8901", VehicleInformation = "2020 Nissan Rogue", StoreId = 9 }
            };

            return drivers;
        }
    }

}
