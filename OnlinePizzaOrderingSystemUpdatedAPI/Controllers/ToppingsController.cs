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
    public class ToppingsController : ControllerBase
    {
        private readonly IToppingService _toppingService;
        private readonly AppDbContext _context;

        public ToppingsController(IToppingService toppingService, AppDbContext context)
        {
            _toppingService = toppingService;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var toppings = await _toppingService.GetAll();

            if (toppings == null) return BadRequest("No Toppings Founded.");

            var toppingsDtoList = new List<ToppingDto>();
            foreach (var topping in toppings)
            {
                toppingsDtoList.Add(new ToppingDto
                {
                    AdditionalCost = topping.AdditionalCost,
                    Description = topping.Description,
                    Id = topping.Id,
                    Name = topping.Name,
                    PizzaId = topping.PizzaId,
                    PizzaName = (topping.Pizza.Name is null) ? "N/A" : topping.Pizza.Name,
                });
            }


            return Ok(toppingsDtoList);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var topping = await _toppingService.GetById(id);

            if (topping == null)
                return BadRequest($"No topping with id: {id}");

            return Ok(topping);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ToppingModel dto)
        {
            var isValidPizzaId = await _context.Pizzas.AnyAsync(x => x.Id == dto.PizzaId);
            if (!isValidPizzaId)
                return BadRequest("Invalid pizza ID !!");

            var topping = new Topping
            {
                Id = dto.Id,
                AdditionalCost = dto.AdditionalCost,
                Description = dto.Description,
                Name = dto.Name,
                PizzaId = dto.PizzaId
            };

            await _toppingService.Create(topping);

            return Ok(topping);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ToppingModel dto)
        {
            var topping = await _toppingService.GetById(id);

            if (topping == null)
                return NotFound($"No topping was found with ID: {id}");

            var isValidPizzaId = await _context.Pizzas.AnyAsync(x => x.Id == dto.PizzaId);
            if (!isValidPizzaId)
                return BadRequest("Invalid pizza ID !!");

            topping.Name = dto.Name;
            topping.Description = dto.Description;
            topping.AdditionalCost = dto.AdditionalCost;
            topping.PizzaId = dto.PizzaId;

            await _toppingService.Update(topping);

            return Ok(topping);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var topping = await _toppingService.GetById(id);

            if (topping == null)
                return NotFound($"No topping was found with id '{id}' to be deleted !!");

            await _toppingService.Delete(topping);

            return Ok(topping);
        }
    }
}
