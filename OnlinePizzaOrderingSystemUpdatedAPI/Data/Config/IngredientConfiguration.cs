using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Cost)
                .HasPrecision(15, 2)
                .IsRequired();

            builder.HasOne(x => x.Supplier)
                .WithMany(x => x.Ingredients)
                .HasForeignKey(x => x.SupplierId)
                .IsRequired();

            builder.ToTable("Ingredients");

            builder.HasData(GetIngredients());
        }

        private static List<Ingredient> GetIngredients()
        {
            return new()
            {
                new Ingredient { Id = 1, Name = "Flour", Cost = 0.99M, SupplierId = 1 },
                new Ingredient { Id = 3, Name = "Salt", Cost = 0.50M, SupplierId = 2 },
                new Ingredient { Id = 4, Name = "Butter", Cost = 2.50M, SupplierId = 3 },
                new Ingredient { Id = 5, Name = "Eggs", Cost = 3.00M, SupplierId = 4 },
                new Ingredient { Id = 6, Name = "Milk", Cost = 1.50M, SupplierId = 5 },
                new Ingredient { Id = 7, Name = "Baking powder", Cost = 0.99M, SupplierId = 6 },
                new Ingredient { Id = 8, Name = "Baking soda", Cost = 0.50M, SupplierId = 7 },
                new Ingredient { Id = 9, Name = "Vanilla extract", Cost = 1.99M, SupplierId = 8 },
                new Ingredient { Id = 10, Name = "Chocolate chips", Cost = 2.99M, SupplierId = 9 },
                new Ingredient { Id = 11, Name = "Cocoa powder", Cost = 2.50M, SupplierId = 10 },
            };
        }
    }

}
