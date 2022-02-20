using AutoMapper;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Dtos.Book;
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

        // GET /api/books
        [HttpGet]
        public async Task<IActionResult> GetBooks(string query = null) 
        {
            var books = await bookRepository.GetAllAvailableBooksWithGenreFilteredByNameAsync(query);
            var response = books.Select(mapper.Map<Book, BookDto>);
            
            return Ok(response);
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await bookRepository.GetByIdWithGenreAsync(id);

            if (book is null)
                return NotFound();

            var response = mapper.Map<BookDetailsDto>(book);

            return Ok(response);
        }

        // POST /api/books/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(NewBookDto newBookDto)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var book = mapper.Map<Book>(newBookDto);
            var bookId = await bookRepository.AddAsync(book);

            var savedBook = await bookRepository.GetByIdWithGenreAsync(bookId);
            var response = mapper.Map<BookDetailsDto>(savedBook);

            return Ok(response);
        }

        // PUT api/books/{id}
        [HttpPut("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto updateBookDto)
        {
            updateBookDto.Id = id;

            if (!ModelState.IsValid)
                return BadRequest();

            var book = mapper.Map<Book>(updateBookDto);

            if (await bookRepository.UpdateAsync(book))
                return Ok();

            return NotFound();
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (await bookRepository.DeleteByIdAsync(id))
                return Ok();

            return NotFound();
        }
    }
}
