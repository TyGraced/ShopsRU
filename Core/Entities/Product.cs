using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }
        
        [Required]
        public bool IsGrocery { get; set; }
    }

}