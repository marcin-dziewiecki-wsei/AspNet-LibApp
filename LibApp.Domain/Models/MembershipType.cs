using LibApp.Domain.Models.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Models
{
    public class MembershipType: EntityBase, IEntityTinyId
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static byte Free = 1;
        public static byte Standard = 2;
        public static byte Silver = 3;
        public static byte Gold = 4;
    }
}
