using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaOrderingSystemUpdatedAPI.Contracts;

public interface ICouponService
{
    Task<IEnumerable<Coupon>> GetAll();
    Task<Coupon> GetById(int id);
    Task<Coupon> Create(Coupon coupon);
}
