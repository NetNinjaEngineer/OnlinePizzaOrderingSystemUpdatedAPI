using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name).HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(15, 2)
                .IsRequired();

            builder.ToTable("MenuItems");
            builder.HasData(GetMenuItems());
        }

        private static List<MenuItem> GetMenuItems()
        {
            List<MenuItem> menuItems = new List<MenuItem>
            {
                new MenuItem { Id = 1, Name = "Cheeseburger", Description = "Juicy beef burger topped with melted cheese", Price = 9.99m },
                new MenuItem { Id = 2, Name = "Margherita Pizza", Description = "Classic pizza with tomato sauce, mozzarella cheese, and fresh basil", Price = 11.99m },
                new MenuItem { Id = 3, Name = "Caesar Salad", Description = "Fresh romaine lettuce with croutons, parmesan cheese, and Caesar dressing", Price = 7.99m },
                new MenuItem { Id = 4, Name = "Spaghetti Carbonara", Description = "Pasta with bacon, eggs, cream, and parmesan cheese", Price = 12.99m },
                new MenuItem { Id = 5, Name = "Fish and Chips", Description = "Crispy battered fish with French fries and tartar sauce", Price = 10.99m },
                new MenuItem { Id = 6, Name = "Chicken Alfredo", Description = "Pasta with grilled chicken and creamy Alfredo sauce", Price = 13.99m },
                new MenuItem { Id = 7, Name = "Grilled Salmon", Description = "Fresh salmon fillet grilled to perfection with lemon butter sauce", Price = 14.99m },
                new MenuItem { Id = 8, Name = "Beef Stir Fry", Description = "Sliced beef with mixed vegetables in a savory sauce, served over rice", Price = 11.99m },
                new MenuItem { Id = 9, Name = "Veggie Wrap", Description = "Grilled vegetables with hummus and feta cheese, wrapped in a spinach tortilla", Price = 8.99m },
                new MenuItem { Id = 10, Name = "BBQ Ribs", Description = "Slow-cooked pork ribs with BBQ sauce and coleslaw", Price = 15.99m },
                new MenuItem { Id = 11, Name = "Mushroom Risotto", Description = "Creamy Arborio rice with mushrooms and parmesan cheese", Price = 10.99m },
                new MenuItem { Id = 12, Name = "Beef Tacos", Description = "Three soft tacos with seasoned beef, lettuce, cheese, and salsa", Price = 9.99m },
                new MenuItem { Id = 13, Name = "Shrimp Scampi", Description = "Pasta with shrimp, garlic, butter, and white wine sauce", Price = 13.99m },
                new MenuItem { Id = 14, Name = "Vegetable Curry", Description = "Mixed vegetables in a spicy curry sauce, served over rice", Price = 10.99m },
                new MenuItem { Id = 15, Name = "Chicken Caesar Wrap", Description = "Grilled chicken with romaine lettuce, croutons, and Caesar dressing, wrapped in a flour tortilla", Price = 8.99m }
            };

            return menuItems;
        }
    }
}
