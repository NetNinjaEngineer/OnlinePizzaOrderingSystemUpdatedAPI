using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class ToppingConfiguration : IEntityTypeConfiguration<Topping>
    {
        public void Configure(EntityTypeBuilder<Topping> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.AdditionalCost)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.Pizza)
                .WithMany(x => x.Toppings)
                .HasForeignKey(x => x.PizzaId)
                .IsRequired(false);

            builder.ToTable("Toppings");

            builder.HasData(GetToppings());
        }

        private static List<Topping> GetToppings()
        {
            return new List<Topping>()
            {
                new Topping { Id = 1, Name = "Pepperoni", Description = "Spicy cured pork sausage", AdditionalCost = 1.50m, PizzaId = 1 },
                new Topping { Id = 2, Name = "Mushrooms", Description = "Sliced mushrooms", AdditionalCost = 0.75m, PizzaId = 1 },
                new Topping { Id = 3, Name = "Green Peppers", Description = "Sliced green bell peppers", AdditionalCost = 0.75m, PizzaId = 2 },
                new Topping { Id = 4, Name = "Onions", Description = "Sliced onions", AdditionalCost = 0.75m, PizzaId = 2 },
                new Topping { Id = 5, Name = "Sausage", Description = "Ground pork sausage", AdditionalCost = 1.50m, PizzaId = 3 },
                new Topping { Id = 6, Name = "Bacon", Description = "Crispy bacon bits", AdditionalCost = 1.50m, PizzaId = 3 },
                new Topping { Id = 7, Name = "Black Olives", Description = "Sliced black olives", AdditionalCost = 0.75m, PizzaId = 4 },
                new Topping { Id = 8, Name = "Jalapenos", Description = "Sliced jalapeno peppers", AdditionalCost = 0.75m, PizzaId = 4 },
                new Topping { Id = 9, Name = "Pineapple", Description = "Diced pineapple chunks", AdditionalCost = 0.75m, PizzaId = 5 },
                new Topping { Id = 10, Name = "Ham", Description = "Diced ham pieces", AdditionalCost = 1.50m, PizzaId = 5 }
            };
        }
    }
}
