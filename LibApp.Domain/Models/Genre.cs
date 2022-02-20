using LibApp.Domain.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Models
{
    public class Genre : EntityBase, IEntityName, IEntityTinyId
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}
