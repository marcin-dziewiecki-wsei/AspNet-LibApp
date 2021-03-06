using LibApp.Domain.Models.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Models
{
    public class Customer : EntityBase, IEntityName, IEntityId
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter customer's name")]
        [StringLength(255)]
        public string Name { get; set; }
        public bool HasNewsletterSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name="Membership Type")]
        public byte MembershipTypeId { get; set; }
        [Display(Name="Date of Birth")]
        [Min18YearsIfMember]
        public DateTime? Birthdate { get; set; }
        
    }
}