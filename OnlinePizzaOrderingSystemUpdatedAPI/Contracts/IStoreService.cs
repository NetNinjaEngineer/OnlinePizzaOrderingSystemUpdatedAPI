using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Contracts;

public interface IStoreService
{
    Task<IEnumerable<Store>> GetAll();
    Task<Store> GetById(int id);
    Task<Store> Create(Store store);
    Task<Store> Update(Store store);
    Task<Store> Delete(Store store);
}
