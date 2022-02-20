using AutoMapper;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Dtos;
using LibApp.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BooksController(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetBooks(string query = null) 
        {
            var books = await bookRepository.GetAllAvailableBooksFilteredByNameAsync(query);
            var response = books.Select(mapper.Map<Book, BookDto>);
            
            return Ok(response);
        }

        
    }
}
