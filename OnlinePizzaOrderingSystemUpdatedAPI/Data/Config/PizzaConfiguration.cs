using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Size)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(15, 2)
                .IsRequired();

            builder.ToTable("Pizzas");
            builder.HasData(GetPizzas());
        }

        private static List<Pizza> GetPizzas()
        {
            return new List<Pizza>()
            {
                new Pizza { Id = 1, Name = "Pepperoni", Size = 12.0, Price = 30.25m },
                new Pizza { Id = 2, Name = "Vegetarian", Size = 10.0, Price = 20  },
                new Pizza { Id = 3, Name = "Meat Lovers", Size = 16.0, Price = 100 },
                new Pizza { Id = 4, Name = "Supreme", Size = 14.0 , Price = 25.50m},
                new Pizza { Id = 5, Name = "Hawaiian", Size = 12.0 , Price = 30.25m},
                new Pizza { Id = 6, Name = "Margherita", Size = 14.0 , Price = 35.75m},
                new Pizza { Id = 7, Name = "BBQ Chicken", Size = 16.0 , Price = 70m},
                new Pizza { Id = 8, Name = "Buffalo Chicken", Size = 12.0 , Price = 48m},
                new Pizza { Id = 9, Name = "Sausage and Mushroom", Size = 14.0 , Price = 92m},
                new Pizza { Id = 10, Name = "Four Cheese", Size = 12.0 , Price = 59m}
            };
        }
    }
}
