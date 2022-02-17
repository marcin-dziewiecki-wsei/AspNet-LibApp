using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CustomersController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET /api/customers
        [HttpGet]
        public async Task<IActionResult> GetCustomers(string query = null)
        {
            IQueryable<Customer> customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(c => c.Name.Contains(query));
            }

            var customerDtos = (await customersQuery
                .ToListAsync())
                .Select(_mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET /api/customers/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(int id)
        {
            Console.WriteLine("Request beginning");

            var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            await Task.Delay(2000);
            if (customer == null)
            {
                return NotFound();
            }

            Console.WriteLine("Request end");

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // POST /api/customers/
        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            customerDto.Id = customer.Id;

            return Ok(customerDto);
        }

        // PUT api/customers/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customerDto.Id);
            if (customerInDb == null)
            {
                return NotFound();
            }


            _mapper.Map(customerDto, customerInDb);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE /api/customers
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCusomer(int id)
        {
            var customerInDb = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
