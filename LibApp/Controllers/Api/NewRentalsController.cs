using LibApp.Data.Data;
using LibApp.Domain.Dtos;
using LibApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        public NewRentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateNewRental([FromBody] NewRentalDto newRental)
        {
            var customer = _context.Customers
                .Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == newRental.CustomerId);

            var books = _context.Books
                .Include(b => b.Genre)
                .Where(b => newRental.BookIds.Contains(b.Id)).ToList();

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is not available");

                book.NumberAvailable--;
                var rental = new Rental()
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }

        private readonly ApplicationDbContext _context;
    }
}
