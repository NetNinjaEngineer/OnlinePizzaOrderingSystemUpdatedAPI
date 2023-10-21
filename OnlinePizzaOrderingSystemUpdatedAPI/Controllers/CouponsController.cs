using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlinePizzaOrderingSystemUpdatedAPI.Contracts;
using OnlinePizzaOrderingSystemUpdatedAPI.Data;
using OnlinePizzaOrderingSystemUpdatedAPI.Dtos;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponsController : ControllerBase
    {
        private readonly ICouponService _couponService;
        private readonly AppDbContext _context;

        public CouponsController(ICouponService couponService, AppDbContext context)
        {
            _couponService = couponService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var coupons = await _couponService.GetAll();

            if (coupons == null)
                return BadRequest("No coupons found");

            var dto = coupons.Select(x => new CouponDto
            {
                Id = x.Id,
                UsageCount = x.UsageCount,
                ExpirationDate = x.ExpirationDate,
                DiscountAmount = x.DiscountAmount,
                Code = x.Code,
                CustomerName = x.Customer.Name,
                CustomerId = x.CustomerId,
            });


            return Ok(dto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var coupon = await _couponService.GetById(id);

            if (coupon == null)
                return BadRequest("No coupon founded !!");

            var dto = new CouponDto
            {
                Id = coupon.Id,
                UsageCount = coupon.UsageCount,
                ExpirationDate = coupon.ExpirationDate,
                DiscountAmount = coupon.DiscountAmount,
                CustomerName = coupon.Customer.Name,
                Code = coupon.Code,
                CustomerId = coupon.CustomerId,
            };

            return Ok(dto);
        }

        [HttpGet("GetByCode")]
        public async Task<IActionResult> GetByCodeAsync(string code)
        {
            var coupon = await _context.Coupons
                .Include(x => x.Customer)
                .SingleOrDefaultAsync(x => x.Code.Equals(code));
            if (coupon == null)
                return BadRequest($"No coupon with code '{code}'");

            var dto = new CouponDto
            {
                Code = coupon.Code,
                CustomerId = coupon.CustomerId,
                CustomerName = coupon.Customer.Name,
                ExpirationDate = coupon.ExpirationDate,
                DiscountAmount = coupon.DiscountAmount,
                UsageCount = coupon.UsageCount,
                Id = coupon.Id
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CouponModel dto)
        {
            var isValidCustomerId = await _context.Customers.AnyAsync(x => x.Id == dto.CustomerId);
            if (!isValidCustomerId)
                return BadRequest("Invalid customer id");

            var coupon = new Coupon
            {
                Id = dto.Id,
                Code = dto.Code,
                CustomerId = dto.CustomerId,
                DiscountAmount = dto.DiscountAmount,
                ExpirationDate = dto.ExpirationDate,
                UsageCount = dto.UsageCount,
            };

            if (coupon == null)
                return BadRequest("No coupons found");

            await _couponService.Create(coupon);

            return Ok(coupon);
        }

    }
}
