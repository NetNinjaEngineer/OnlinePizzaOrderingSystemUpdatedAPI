using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class CouponConfiguration : IEntityTypeConfiguration<Coupon>
    {
        public void Configure(EntityTypeBuilder<Coupon> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Code)
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.DiscountAmount)
                .HasPrecision(15, 2)
                .IsRequired();

            builder.Property(x => x.ExpirationDate)
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(x => x.UsageCount)
                .IsRequired();

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Coupon)
                .HasForeignKey<Coupon>(x => x.CustomerId)
                .IsRequired();

            builder.ToTable("Coupons");
            builder.HasData(GetCoupons());
        }

        private static List<Coupon> GetCoupons()
        {
            var coupons = new List<Coupon>
            {
                new Coupon { Id = 1, Code = "SUMMER25", DiscountAmount = 25.00M, ExpirationDate = new DateTime(2023, 8, 31), UsageCount = 5, CustomerId = 1 },
                new Coupon { Id = 2, Code = "FALL20", DiscountAmount = 20.00M, ExpirationDate = new DateTime(2023, 11, 30), UsageCount = 10, CustomerId = 2 },
                new Coupon { Id = 3, Code = "WINTER15", DiscountAmount = 15.00M, ExpirationDate = new DateTime(2024, 2, 28), UsageCount = 20, CustomerId = 3 },
                new Coupon { Id = 4, Code = "SPRING10", DiscountAmount = 10.00M, ExpirationDate = new DateTime(2024, 5, 31), UsageCount = 15, CustomerId = 4 },
                new Coupon { Id = 5, Code = "NEWYEAR30", DiscountAmount = 30.00M, ExpirationDate = new DateTime(2023, 1, 31), UsageCount = 2, CustomerId = 5 },
                new Coupon { Id = 6, Code = "MEMORIAL20", DiscountAmount = 20.00M, ExpirationDate = new DateTime(2023, 5, 31), UsageCount = 10, CustomerId = 6 },
                new Coupon { Id = 7, Code = "LABORDAY15", DiscountAmount = 15.00M, ExpirationDate = new DateTime(2023, 9, 30), UsageCount = 5, CustomerId = 7 },
                new Coupon { Id = 8, Code = "HALLOWEEN10", DiscountAmount = 10.00M, ExpirationDate = new DateTime(2023, 10, 31), UsageCount = 8, CustomerId = 8 },
                new Coupon { Id = 9, Code = "BLACKFRIDAY25", DiscountAmount = 25.00M, ExpirationDate = new DateTime(2023, 11, 24), UsageCount = 3, CustomerId = 9 },
                new Coupon { Id = 10, Code = "CYBERMONDAY20", DiscountAmount = 20.00M, ExpirationDate = new DateTime(2023, 11, 27), UsageCount = 5, CustomerId = 10 },
                new Coupon { Id = 11, Code = "CHRISTMAS30", DiscountAmount = 30.00M, ExpirationDate = new DateTime(2023, 12, 31), UsageCount = 2, CustomerId = 11 },
                new Coupon { Id = 12, Code = "VALENTINE15", DiscountAmount = 15.00M, ExpirationDate = new DateTime(2024, 2, 14), UsageCount = 10, CustomerId = 12 },
                new Coupon { Id = 13, Code = "EASTER10", DiscountAmount = 10.00M, ExpirationDate = new DateTime(2024, 4, 21), UsageCount = 15, CustomerId = 13 },
                new Coupon { Id = 14, Code = "MOTHERSDAY25", DiscountAmount = 25.00M, ExpirationDate = new DateTime(2024, 5, 12), UsageCount = 5, CustomerId = 14 },
                new Coupon { Id = 15, Code = "FATHERSDAY20", DiscountAmount = 20.00M, ExpirationDate = new DateTime(2024, 6, 16), UsageCount = 8, CustomerId = 15 },
            };

            return coupons;
        }
    }

}
