using Microsoft.EntityFrameworkCore;
using OnlinePizzaOrderingSystemUpdatedAPI.Contracts;
using OnlinePizzaOrderingSystemUpdatedAPI.Data;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly AppDbContext _context;

        public CustomerService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Create(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Delete(Customer customer)
        {
            _context.Remove(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var all = await _context.Customers
                .Include(x => x.Coupon)
                .Include(x => x.OrderMenuItems)
                .Include(x => x.MenuItems)
                .Include(x => x.MenuItems)
                .Include(x => x.Payment)
                .ToListAsync();
            return all!;
        }

        public async Task<Customer> GetById(int id)
        {
            var payment = await _context.Customers
                .Include(x => x.Coupon)
                .Include(x => x.OrderMenuItems)
                .Include(x => x.MenuItems)
                .Include(x => x.MenuItems)
                .Include(x => x.Payment)
                .SingleOrDefaultAsync(x => x.Id == id);
            return payment!;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
    }
}
