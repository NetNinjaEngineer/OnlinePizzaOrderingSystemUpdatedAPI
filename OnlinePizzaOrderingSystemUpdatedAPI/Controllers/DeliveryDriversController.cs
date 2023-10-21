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
    public class DeliveryDriversController : ControllerBase
    {
        private readonly IDeliveryDriverService _service;
        private readonly AppDbContext _context;

        public DeliveryDriversController(IDeliveryDriverService service, AppDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var all = await _service.GetAll();
            if (all == null)
                return BadRequest("No delivery drivers found !!");
            var dtoList = new List<DeliveryDriverDetails>();
            foreach (var item in all)
            {
                dtoList.Add(new DeliveryDriverDetails
                {
                    Id = item.Id,
                    Name = item.Name,
                    PhoneNumber = item.PhoneNumber,
                    StoreId = item.StoreId,
                    StoreName = item.Store.StoreName,
                    VehicleInformation = item.VehicleInformation
                });
            }
            return Ok(dtoList);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var driver = await _service.GetById(id);

            if (driver == null)
                return BadRequest($"No delivery driver with id: {id} founded !!");

            var deliveryDetails = new DeliveryDriverDetails
            {
                Id = driver.Id,
                Name = driver.Name,
                PhoneNumber = driver.PhoneNumber,
                StoreId = driver.StoreId,
                VehicleInformation = driver.VehicleInformation,
                StoreName = driver.Store.StoreName
            };

            return Ok(deliveryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DeliveryDriverDto dto)
        {
            if (dto == null)
                return BadRequest("Invalid deliver, you must fill it again !!");

            var isValidStore = await _context.Stores.AnyAsync(x => x.Id == dto.StoreId);
            if (!isValidStore)
                return BadRequest("Invalid store Id !!");

            var driver = new DeliveryDriver
            {
                Id = dto.Id,
                Name = dto.Name,
                PhoneNumber = dto.PhoneNumber,
                StoreId = dto.StoreId,
                VehicleInformation = dto.VehicleInformation,
            };

            await _service.Create(driver);

            return Ok(driver);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] DeliveryDriverDto dto)
        {
            var deliveryDriver = await _service.GetById(id);
            if (deliveryDriver == null)
                return BadRequest($"No delivery found with id: {id}");

            var isValidStoreId = await _context.Stores.AnyAsync(x => x.Id == dto.StoreId);
            if (!isValidStoreId)
                return BadRequest("Invalid store id !!");

            deliveryDriver.PhoneNumber = dto.PhoneNumber;
            deliveryDriver.Name = dto.Name;
            deliveryDriver.VehicleInformation = dto.VehicleInformation;
            deliveryDriver.StoreId = dto.StoreId;
            deliveryDriver.Id = dto.Id;

            await _service.Update(deliveryDriver);
            return Ok(deliveryDriver);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deletedDelivery = await _service.GetById(id);

            if (deletedDelivery == null)
                return NotFound($"No delivery driver was found with id '{id}' to be deleted !!");

            await _service.Delete(deletedDelivery);

            return Ok(deletedDelivery);
        }

    }
}
