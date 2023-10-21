using Microsoft.EntityFrameworkCore;
using OnlinePizzaOrderingSystemUpdatedAPI.Contracts;
using OnlinePizzaOrderingSystemUpdatedAPI.Data;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Services
{
    public class CouponService : ICouponService
    {
        private readonly AppDbContext _context;

        public CouponService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Coupon> Create(Coupon coupon)
        {
            _context.Coupons.Add(coupon);
            await _context.SaveChangesAsync();
            return coupon;
        }

        public async Task<IEnumerable<Coupon>> GetAll()
        {
            var coupons = await _context.Coupons
                .Include(x => x.Customer)
                .ToListAsync();
            return coupons;
        }

        public async Task<Coupon> GetById(int id)
        {
            var coupon = await _context.Coupons
                .Include(x => x.Customer)
                .FirstOrDefaultAsync(x => x.Id == id);
            return coupon;
        }
    }
}
