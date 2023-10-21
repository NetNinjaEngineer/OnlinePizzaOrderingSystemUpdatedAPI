namespace OnlinePizzaOrderingSystemUpdatedAPI.Dtos
{
    public class CouponDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int UsageLimit => UsageCount--;
        public int UsageCount { get; set; }
        public string CustomerName { get; set; }
        public int? CustomerId { get; set; } = null!;
    }
}
