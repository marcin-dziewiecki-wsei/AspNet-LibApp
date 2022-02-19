using System.ComponentModel.DataAnnotations;

namespace LibApp.Domain.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        public static byte Unknown = 0;
        public static byte PayAsYouGo = 1;
    }
}
