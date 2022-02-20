using System;

namespace LibApp.Domain.Dtos.Book
{
    public class NewBookDto
    {
		public string Name { get; set; }
		public string AuthorName { get; set; }
		public byte GenreId { get; set; }
		public DateTime ReleaseDate { get; set; }
		public int NumberInStock { get; set; }
	}
}
