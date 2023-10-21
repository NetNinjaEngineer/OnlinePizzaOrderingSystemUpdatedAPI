using OnlinePizzaOrderingSystemUpdatedAPI.Enums;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public TimeSpan OrderTime { get; set; }
        public decimal TotalCost { get; set; }
        public DeliveryOptions DeliveryOptions { get; set; }
        public string? OptionName { get; set; }
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public int DeliveryDriverId { get; set; }
        public string? DeliveryDriverName { get; set; }
    }
}
