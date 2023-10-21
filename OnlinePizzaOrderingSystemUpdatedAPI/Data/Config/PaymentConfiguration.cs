using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlinePizzaOrderingSystemUpdatedAPI.Enums;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Data.Config
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.PaymentAmount)
                .HasPrecision(18, 2)
                .IsRequired();

            builder.Property(x => x.PaymentMethod)
                .HasConversion(
                    x => x.ToString(),
                    x => (PaymentMethod)Enum.Parse(typeof(PaymentMethod), x)
                );

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Payment)
                .HasForeignKey<Payment>(x => x.CustomerId)
                .IsRequired();

            builder.HasData(GetPayments());

            builder.ToTable("Payments");
        }

        private static List<Payment> GetPayments()
        {
            return new List<Payment>()
            {
                new Payment { Id = 1, PaymentAmount = 50.0m, PaymentMethod = PaymentMethod.CreditCard, CustomerId = 1 },
                new Payment { Id = 2, PaymentAmount = 25.0m, PaymentMethod = PaymentMethod.Cash, CustomerId = 2 },
                new Payment { Id = 3, PaymentAmount = 75.0m, PaymentMethod = PaymentMethod.MobilePayment, CustomerId = 3 },
                new Payment { Id = 4, PaymentAmount = 100.0m, PaymentMethod = PaymentMethod.GiftCards, CustomerId = 4 },
                new Payment { Id = 5, PaymentAmount = 60.0m, PaymentMethod = PaymentMethod.DigitalWallets, CustomerId = 5 },
                new Payment { Id = 6, PaymentAmount = 80.0m, PaymentMethod = PaymentMethod.Cryptocurrency, CustomerId = 6 },
                new Payment { Id = 7, PaymentAmount = 30.0m, PaymentMethod = PaymentMethod.Checks, CustomerId = 7 }
            };
        }
    }
}
