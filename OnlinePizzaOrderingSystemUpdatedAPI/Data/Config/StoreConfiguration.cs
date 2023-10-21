using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.StoreManager)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.StoreName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("Stores");

            builder.HasData(GetStores());
        }

        private static List<Store> GetStores()
        {
            return new()
            {
                new Store{ Id = 1, StoreName = "ABC Grocery",  StoreManager = "John Doe" },
                new Store{ Id = 2, StoreName = "XYZ Pharmacy", StoreManager = "Jane Smith" },
                new Store{ Id = 3, StoreName = "XYZ Pharmacy", StoreManager = "Sara Lee" },
                new Store{ Id = 4, StoreName = "123 Mart",     StoreManager = "Bob Johnson" },
                new Store{ Id = 5, StoreName = "456 Pharmacy", StoreManager = "Alice Smith" },
                new Store{ Id = 6, StoreName = "GHI Hardware", StoreManager = "Mike Brown" },
                new Store{ Id = 7, StoreName = "JKL Grocery", StoreManager = "Tom Wilson" },
                new Store{ Id = 8, StoreName = "MNO Pharmacy", StoreManager = "Sara Lee" },
                new Store{ Id = 9, StoreName = "PQR Hardware", StoreManager = "John Doe" },
                new Store{ Id = 10,StoreName = "STU Grocery", StoreManager = "Jane Smith" },
            };
        }
    }
}
