using AutoMapper;
using LibApp.Data.Repository.Interfaces;
using LibApp.Domain.Dtos.Book;
using LibApp.Domain.Models;
using LibApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Services
{
    internal class BookService: IBookService
    {
        private readonly IBookRepository bookRepository;
        private readonly IMapper mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
        }

        public async Task<BookDetailsDto> CreateBook(NewBookDto newBookDto)
        {
            var book = mapper.Map<Book>(newBookDto);
            var bookId = await bookRepository.AddAsync(book);

            var savedBook = await bookRepository.GetByIdWithGenreAsync(bookId);
            var response = mapper.Map<BookDetailsDto>(savedBook);

            return response;
        }

        public async Task<bool> DeleteBook(int id)
            => await bookRepository.DeleteByIdAsync(id);

        public async Task<IList<BookDto>> GetAllBooks(string query = null)
        {
            var books = await bookRepository.GetAllAvailableBooksWithGenreFilteredByNameAsync(query);
            var response = books.Select(x => mapper.Map<BookDto>(x)).ToList();

            return response;
        }

        public async Task<BookDetailsDto> GetBookDetails(int id)
        {
            var book = await bookRepository.GetByIdWithGenreAsync(id);
            
            if (book is null)
                return null;
            
            var response = mapper.Map<BookDetailsDto>(book);
            return response;
        }

        public async Task<bool> UpdateBook(UpdateBookDto updateBookDto)
        {
            var book = mapper.Map<Book>(updateBookDto);
            var response = await bookRepository.UpdateAsync(book);
            return response;
        }
    }
}
