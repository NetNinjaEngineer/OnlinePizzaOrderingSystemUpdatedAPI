using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
    {
        public void Configure(EntityTypeBuilder<Supplier> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.ToTable("Suppliers");
            builder.HasData(GetSuppliers());
        }

        private static List<Supplier> GetSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>()
            {
                new Supplier { Id = 1, Name = "Acme Foods" },
                new Supplier { Id = 2, Name = "Global Ingredients" },
                new Supplier { Id = 3, Name = "Organic Farms Inc." },
                new Supplier { Id = 4, Name = "Gourmet Foods" },
                new Supplier { Id = 5, Name = "Premium Ingredients" },
                new Supplier { Id = 6, Name = "Food Service Distributors" },
                new Supplier { Id = 7, Name = "Sysco Corporation" },
                new Supplier { Id = 8, Name = "US Foods Inc." },
                new Supplier { Id = 9, Name = "Gordon Food Service" },
                new Supplier { Id = 10, Name = "Performance Food Group" }
            };

            return suppliers;
        }
    }
}
