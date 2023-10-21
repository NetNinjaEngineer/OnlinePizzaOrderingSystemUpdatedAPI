using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Address)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
              .HasColumnType("VARCHAR")
              .HasMaxLength(100)
              .IsRequired();

            builder.Property(x => x.PhoneNumber)
              .HasColumnType("VARCHAR")
              .HasMaxLength(11)
              .IsRequired();

            builder.ToTable("Locations");
            builder.HasData(GetLocations());
        }

        private static List<Location> GetLocations()
        {
            var locations = new List<Location>
            {
                new Location { Id = 1, Address = "123 Main St", PhoneNumber = "555-1234", Email = "info@location1.com" },
                new Location { Id = 2, Address = "456 Elm St", PhoneNumber = "555-5678", Email = "info@location2.com" },
                new Location { Id = 3, Address = "789 Oak St", PhoneNumber = "555-2468", Email = "info@location3.com" },
                new Location { Id = 4, Address = "321 Pine St", PhoneNumber = "555-7890", Email = "info@location4.com" },
                new Location { Id = 5, Address = "654 Cedar St", PhoneNumber = "555-1357", Email = "info@location5.com" }
            };

            return locations;
        }
    }
}
