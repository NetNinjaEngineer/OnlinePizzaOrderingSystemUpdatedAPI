using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DeliveryAddress)
               .HasColumnType("VARCHAR")
               .HasMaxLength(150)
               .IsRequired();

            builder.Property(x => x.Email)
                 .HasColumnType("VARCHAR")
                 .HasMaxLength(100)
                 .IsRequired();

            builder.HasMany(x => x.MenuItems)
                .WithMany(x => x.Customers)
                .UsingEntity<CustomerMenuItems>();

            builder.ToTable("Customers");
            builder.HasData(GetCustomers());
        }

        private static List<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
                new Customer { Id = 1, Name = "John Smith", Email = "john.smith@example.com", DeliveryAddress = "123 Main St" },
                new Customer { Id = 2, Name = "Jane Doe", Email = "jane.doe@example.com", DeliveryAddress = "456 Oak Ave" },
                new Customer { Id = 3, Name = "Bob Johnson", Email = "bob.johnson@example.com", DeliveryAddress = "789 Elm St" },
                new Customer { Id = 4, Name = "Sarah Lee", Email = "sarah.lee@example.com", DeliveryAddress = "321 Maple Rd" },
                new Customer { Id = 5, Name = "David Kim", Email = "david.kim@example.com", DeliveryAddress = "654 Pine Blvd" },
                new Customer { Id = 6, Name = "Maria Hernandez", Email = "maria.hernandez@example.com", DeliveryAddress = "987 Cedar Dr" },
                new Customer { Id = 7, Name = "Tom Wilson", Email = "tom.wilson@example.com", DeliveryAddress = "246 Birch Ln" },
                new Customer { Id = 8, Name = "Emily Chen", Email = "emily.chen@example.com", DeliveryAddress = "135 Oakwood Ave" },
                new Customer { Id = 9, Name = "Michael Brown", Email = "michael.brown@example.com", DeliveryAddress = "864 Maple St" },
                new Customer { Id = 10, Name = "Amy Nguyen", Email = "amy.nguyen@example.com", DeliveryAddress = "753 Pine Ave" },
                new Customer { Id = 11, Name = "James Lee", Email = "james.lee@example.com", DeliveryAddress = "246 Cedar Ln" },
                new Customer { Id = 12, Name = "Samantha Patel", Email = "samantha.patel@example.com", DeliveryAddress = "975 Oak St" },
                new Customer { Id = 13, Name = "William Johnson", Email = "william.johnson@example.com", DeliveryAddress = "864 Maple Rd" },
                new Customer { Id = 14, Name = "Linda Davis", Email = "linda.davis@example.com", DeliveryAddress = "753 Pine St" },
                new Customer { Id = 15, Name = "Chris Wilson", Email = "chris.wilson@example.com", DeliveryAddress = "246 Cedar Ave" }
            };
        }
    }

}
