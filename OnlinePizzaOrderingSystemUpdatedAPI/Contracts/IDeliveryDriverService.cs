using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Contracts;

public interface IDeliveryDriverService
{
    Task<IEnumerable<DeliveryDriver>> GetAll();
    Task<DeliveryDriver> GetById(int id);
    Task<DeliveryDriver> Create(DeliveryDriver driver);
    Task<DeliveryDriver> Update(DeliveryDriver driver);
    Task<DeliveryDriver> Delete(DeliveryDriver driver);
}
