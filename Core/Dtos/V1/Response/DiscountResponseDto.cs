using System;

namespace Core.Dtos.V1.Response
{
    public class DiscountResponseDto
    {
        public string DiscountType { get; set; }
        public double PercentageDiscount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
