using LibApp.Domain.Models.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Models
{
    public class Book: EntityBase, IEntityName, IEntityId
    {
        public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }

		[Required]
		public string AuthorName { get; set; }
		[Required]
		public Genre Genre { get; set; }
		[Required]
		[Display(Name = "Genre")]
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Display(Name="Realease Date")]
		public DateTime ReleaseDate { get; set; }
		public int NumberInStock { get; set; }
		public int NumberAvailable { get; set; }
	}
      
}
