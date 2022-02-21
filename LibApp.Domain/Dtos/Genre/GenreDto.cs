using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Dtos.Genre
{
    public class GenreDto
    {
        public byte Id { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
