using LibApp.Domain.Dtos.Book;
using LibApp.Domain.Dtos.Genre;
using System.Collections.Generic;

namespace LibApp.ViewModels
{
    public class BookFormViewModel
    {
        public IEnumerable<GenreDto> Genres { get; set; }
        public BookDetailsDto Book { get; set; }
        public string Title
        {
            get
            {
                if (Book != null && Book.Id != 0)
                {
                    return "Edit Book";
                }

                return "New Book";
            }
        }
    }
}
