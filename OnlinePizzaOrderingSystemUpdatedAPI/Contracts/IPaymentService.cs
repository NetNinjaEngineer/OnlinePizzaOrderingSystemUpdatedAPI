using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Contracts;

public interface IPaymentService
{
    Task<IEnumerable<Payment>> GetAll();
    Task<Payment> GetById(int id);
    Task<Payment> Create(Payment payment);
    Task<Payment> Update(Payment payment);
    Task<Payment> Delete(Payment payment);
}
