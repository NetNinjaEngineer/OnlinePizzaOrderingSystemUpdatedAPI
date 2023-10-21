using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class CustomerMenuItemsConfiguration : IEntityTypeConfiguration<CustomerMenuItems>
    {
        public void Configure(EntityTypeBuilder<CustomerMenuItems> builder)
        {
            builder.HasKey(x => new { x.CustomerId, x.MenuItemId });
            builder.ToTable("CustomerMenuItems");
            builder.HasData(GetMenuItems());
        }

        private static List<CustomerMenuItems> GetMenuItems()
        {
            List<CustomerMenuItems> menuItems = new List<CustomerMenuItems>
            {
                new CustomerMenuItems { MenuItemId = 1, CustomerId = 1, },
                new CustomerMenuItems { MenuItemId = 2,  CustomerId= 2  },
                new CustomerMenuItems { MenuItemId = 3, CustomerId = 3, },
                new CustomerMenuItems { MenuItemId = 4, CustomerId = 4, } ,
                new CustomerMenuItems { MenuItemId = 5, CustomerId = 5, },
                new CustomerMenuItems { MenuItemId = 6, CustomerId = 6, },
                new CustomerMenuItems { MenuItemId = 7, CustomerId = 7, },
                new CustomerMenuItems { MenuItemId = 8, CustomerId = 8, },
                new CustomerMenuItems { MenuItemId = 9, CustomerId = 9, },
                new CustomerMenuItems { MenuItemId = 10,CustomerId = 10,},
                new CustomerMenuItems { MenuItemId = 11, CustomerId = 11 },
                new CustomerMenuItems { MenuItemId = 12,CustomerId = 12},
                new CustomerMenuItems { MenuItemId = 13,CustomerId = 13},
                new CustomerMenuItems { MenuItemId = 14, CustomerId = 14},
                new CustomerMenuItems { MenuItemId = 15, CustomerId = 15 }
            };

            return menuItems;
        }
    }

}
