using OnlinePizzaOrderingSystemUpdatedAPI.Enums;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }

        public int? CustomerId { get; set; } = null!;
    }
}
