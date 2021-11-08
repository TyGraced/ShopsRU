using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.V1.Request
{
    public class CreateInvoiceDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int Count { get; set; }
    }

}