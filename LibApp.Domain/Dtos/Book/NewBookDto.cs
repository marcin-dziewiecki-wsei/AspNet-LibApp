using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Dtos.Book
{
    public class NewBookDto
    {
		[Required(AllowEmptyStrings = false, ErrorMessage = "Book name must be set")]
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Book name must be between 5 and 50 characters long")]
		public string Name { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Author name must be set")]
		[StringLength(50, MinimumLength = 5, ErrorMessage = "Author name must be between 5 and 50 characters long")]
		public string AuthorName { get; set; }

		[Required(ErrorMessage = "Genere must be set")]
		[Range(1, 255, ErrorMessage = "Genere must be properly set")]
		public byte GenreId { get; set; }
		
		[Required(ErrorMessage = "Release date must be set")]
		[DataType(DataType.Date, ErrorMessage = "Release date must be proper date")]
		public DateTime ReleaseDate { get; set; }

		[Required(ErrorMessage = "Number of books in stock must be set")]
		[Range(1,20, ErrorMessage = "Number of books in stock must be betwen 1 and 20")]
		public int NumberInStock { get; set; }
	}
}
