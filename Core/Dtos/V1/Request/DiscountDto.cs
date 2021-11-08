using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.V1.Request
{
    public class DiscountDto
    {
        [Required]
        public double PercentageDiscount { get; set; }

        [Required]
        public string DiscountType { get; set; }
    }
}