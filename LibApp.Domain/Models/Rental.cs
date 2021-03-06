using LibApp.Domain.Models.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Models
{
    public class Rental: EntityBase, IEntityId
    {
        public int Id { get; set; }
        [Required]
        public Customer Customer { get; set; }
        [Required]
        public Book Book { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}
