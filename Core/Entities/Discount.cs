using System;

namespace Core.Entities
{
    public class Discount : BaseEntity
    {
        public string DiscountType { get; set; }
        public double PercentageDiscount { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}