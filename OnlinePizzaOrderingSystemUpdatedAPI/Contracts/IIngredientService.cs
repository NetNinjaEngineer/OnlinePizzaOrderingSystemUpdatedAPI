using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Contracts;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> GetAll();
    Task<Ingredient> GetById(int id);
    Task<Ingredient> Create(Ingredient ingredient);
    Task<Ingredient> Update(Ingredient ingredient);
    Task<Ingredient> Delete(Ingredient ingredient);
}
