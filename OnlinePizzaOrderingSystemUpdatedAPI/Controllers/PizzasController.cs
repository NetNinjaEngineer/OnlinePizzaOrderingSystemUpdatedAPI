using Microsoft.AspNetCore.Mvc;
using OnlinePizzaOrderingSystemUpdatedAPI.Contracts;
using OnlinePizzaOrderingSystemUpdatedAPI.Dtos;
using OnlinePizzaOrderingSystemUpdatedAPI.Models;

namespace OnlinePizzaSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzasController : ControllerBase
    {
        private readonly IPizzaService _pizzaService;

        public PizzasController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var pizzas = await _pizzaService.GetAll();

            var dtoList = new List<PizzaDto>();
            foreach (var pizza in pizzas)
            {
                dtoList.Add(new PizzaDto
                {
                    Id = pizza.Id,
                    Name = pizza.Name,
                    Size = pizza.Size,
                    Price = pizza.Price,
                });
            }

            return Ok(dtoList);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var pizza = await _pizzaService.GetById(id);

            if (pizza == null)
                return BadRequest($"No pizza with id: {id}");

            return Ok(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PizzaDto dto)
        {
            var pizza = new Pizza
            {
                Id = dto.Id,
                Name = dto.Name,
                Size = dto.Size,
                Price = dto.Price,
            };

            await _pizzaService.Create(pizza);

            return Ok(pizza);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] PizzaDto dto)
        {
            var pizza = await _pizzaService.GetById(id);

            if (pizza == null)
                return NotFound($"No pizza was found with ID: {id}");

            pizza.Name = dto.Name;
            pizza.Size = dto.Size;
            pizza.Price = dto.Price;

            await _pizzaService.Update(pizza);

            return Ok(pizza);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var pizza = await _pizzaService.GetById(id);

            if (pizza == null)
                return NotFound($"No pizza was found with id: {id}");

            await _pizzaService.Delete(pizza);

            return Ok(pizza);
        }
    }
}
