using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Discount : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        
        [Required]
        public DiscountType DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }

    public enum DiscountType
    {
        Percentage = 1,
        Amount = 2
    }

}