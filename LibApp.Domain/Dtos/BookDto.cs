using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Dtos
{
    public class BookDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
