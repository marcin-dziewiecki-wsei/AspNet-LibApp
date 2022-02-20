using System;

namespace LibApp.Domain.Dtos.Book
{
    public class BookDetailsDto
    {
		public int Id { get; set; }
		public string Name { get; set; }
		public string AuthorName { get; set; }
		public string Genre { get; set; }
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int NumberInStock { get; set; }
		public int NumberAvailable { get; set; }
	}
}
