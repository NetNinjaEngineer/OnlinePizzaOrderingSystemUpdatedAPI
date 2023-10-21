using Microsoft.EntityFrameworkCore;
using OnlinePizzaOrderingSystemUpdatedAPI.Contracts;
using OnlinePizzaOrderingSystemUpdatedAPI.Data;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class ToppingService : IToppingService
    {
        private readonly AppDbContext _context;

        public ToppingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Topping> Create(Topping topping)
        {
            await _context.AddAsync(topping);
            await _context.SaveChangesAsync();
            return topping;
        }

        public async Task<Topping> Delete(Topping topping)
        {
            _context.Remove(topping);
            await _context.SaveChangesAsync();
            return topping;
        }

        public async Task<IEnumerable<Topping>> GetAll()
        {
            var all = await _context.Toppings
                .Include(x => x.Pizza)
                .ToListAsync();
            return all;
        }

        public async Task<Topping> GetById(int id)
        {
            var topping = await _context.Toppings
                .Include(x => x.Pizza)
                .SingleOrDefaultAsync(x => x.Id == id);
            return topping!;
        }

        public async Task<Topping> Update(Topping topping)
        {
            _context.Toppings.Update(topping);
            await _context.SaveChangesAsync();
            return topping;
        }
    }
}
