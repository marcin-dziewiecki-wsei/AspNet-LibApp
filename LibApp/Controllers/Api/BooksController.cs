using LibApp.Domain.Dtos.Book;
using LibApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService bookService;

        public BooksController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        // GET /api/books
        [HttpGet]
        public async Task<IActionResult> GetBooks(string query = null) 
        {
            var response = await bookService.GetAllBooks(query);
            return Ok(response);
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var response = await bookService.GetBookDetails(id);

            if (response is null) return NotFound();
            else return Ok(response);
        }

        // POST /api/books/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBook(NewBookDto newBookDto)
        {
            if (ModelState.IsValid == false)
                return BadRequest();

            var response = await bookService.CreateBook(newBookDto);
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

            if (await bookService.UpdateBook(updateBookDto))
                return Ok();

            return NotFound();
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteBook(int id)
        {
            if (await bookService.DeleteBook(id))
                return Ok();

            return NotFound();
        }
    }
}
