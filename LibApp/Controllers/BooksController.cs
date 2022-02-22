using AutoMapper;
using LibApp.Domain.Dtos.Book;
using LibApp.Services.Interfaces;
using LibApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LibApp.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly IGenreService genreService;
        private readonly IMapper mapper;

        public BooksController(IBookService bookService, IGenreService genreService, IMapper mapper)
        {
            this.bookService = bookService;
            this.genreService = genreService;
            this.mapper = mapper;
        }

        [Authorize(Policy = "RequireUserRole")]
        public IActionResult Index()
            => View();

        [Authorize(Policy = "RequireUserRole")]
        public async Task<IActionResult> Details(int id)
        {
            var book = await bookService.GetBookDetails(id);

            if (book == null)
                return Content("Book not found");

            return View(book);
        }

        [Authorize(Policy = "RequireManagerRole")]
        public async Task<IActionResult> Edit(int id)
        {
            var book = await bookService.GetBookDetails(id);
            
            if (book == null)
                return NotFound();

            var viewModel = new BookFormViewModel
            {
                Book = book,
                Genres = await genreService.GetAll()
            };

            return View("BookForm", viewModel);
        }

        [Authorize(Policy = "RequireManagerRole")]
        public async Task<IActionResult> New()
        {
            var viewModel = new BookFormViewModel
            {
                Genres = await genreService.GetAll()
            };

            return View("BookForm", viewModel);
        }

        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RequireManagerRole")]
        public async Task<IActionResult> Save(UpdateBookDto book)
        {
            if (ModelState.IsValid == false)
            {
                var viewModel = new BookFormViewModel
                {
                    Book = mapper.Map<BookDetailsDto>(book),
                    Genres = await genreService.GetAll()
                };

                return View("BookForm", viewModel);

            }

            if (book.Id.GetValueOrDefault() == 0)
                await bookService.CreateBook(book);
            else
                await bookService.UpdateBook(book);

            return RedirectToAction("Index", "Books");
        }
    }
}
