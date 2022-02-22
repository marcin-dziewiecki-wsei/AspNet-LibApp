using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Dtos;
using LibApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewRentalsController : ControllerBase
    {
        private readonly IRentalRepository rentalRepository;
        private readonly IBookRepository bookRepository;
        private readonly ICustomerRepository customerRepository;

        public NewRentalsController(IRentalRepository rentalRepository, IBookRepository bookRepository, ICustomerRepository customerRepository)
        {
            this.rentalRepository = rentalRepository;
            this.bookRepository = bookRepository;
            this.customerRepository = customerRepository;
        }

        [HttpPost]
        [Authorize(Policy = "RequireManagerRole")]
        public async Task<IActionResult> CreateNewRental([FromBody] NewRentalDto newRental)
        {
            var customer = await customerRepository.GetByIdWithMemberTypeAsync(newRental.CustomerId);
            var books = await bookRepository.GetAllByIdsWithGenreAsync(newRental.BookIds);

            var rentalsToAdd = new List<Rental>();

            foreach (var book in books)
            {
                if (book.NumberAvailable == 0)
                    return BadRequest("Book is not available");

                book.NumberAvailable--;
                rentalsToAdd.Add(new Rental()
                {
                    Customer = customer,
                    Book = book,
                    DateRented = DateTime.Now
                });
            }

            await rentalRepository.AddRangeAsync(rentalsToAdd);
            return Ok();
        }
    }
}
