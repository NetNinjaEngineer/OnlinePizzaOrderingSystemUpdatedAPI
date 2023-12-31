﻿using OnlinePizzaOrderingSystemUpdatedAPI.Enums;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Dtos
{
    public class PaymentDetailsDto
    {
        public int Id { get; set; }
        public decimal PaymentAmount { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public int? CustomerId { get; set; } = null!;
        public string CustomerName { get; set; }
        public string PayMethod { get; set; }
    }
}
