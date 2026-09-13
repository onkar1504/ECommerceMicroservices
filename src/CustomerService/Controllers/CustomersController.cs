using CustomerService.Data;
using CustomerService.Models;
using CustomerService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerService.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        // GET: api/customers
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _service.GetAllAsync();

            return Ok(customers);
        }

        // GET: api/customers/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _service.GetByIdAsync(id);

            if (customer == null)
                return NotFound();

            return Ok(customer);
        }

        // POST: api/customers
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            var createdCustomer = await _service.CreateAsync(customer);

            return CreatedAtAction(
                nameof(GetById),
                new { id = createdCustomer.Id },
                createdCustomer);
        }

        // PUT: api/customers/1
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Customer customer)
        {
            if (id != customer.Id)
                return BadRequest("ID mismatch.");

            var updated = await _service.UpdateAsync(customer);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/customers/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
