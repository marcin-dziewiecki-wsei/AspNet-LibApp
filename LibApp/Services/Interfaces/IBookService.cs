using LibApp.Domain.Dtos.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibApp.Services.Interfaces
{
    public interface IBookService
    {
        Task<IList<BookDto>> GetAllBooks(string query = null);
        Task<BookDetailsDto> GetBookDetails(int id);
        Task<BookDetailsDto> CreateBook(NewBookDto newBookDto);
        Task<bool> UpdateBook(UpdateBookDto updateBookDto);
        Task<bool> DeleteBook(int id);
    }
}
