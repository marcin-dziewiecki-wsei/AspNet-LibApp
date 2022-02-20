using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Dtos.Book
{
    public class UpdateBookDto: NewBookDto
    {
        [Required(ErrorMessage = "Book id must be set")]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be positive value")]
        public int Id { get; set; }
    }
}
