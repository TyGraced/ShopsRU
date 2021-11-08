using System;

namespace Core.Entities
{
    public class InvoiceProducts : BaseEntity
    {
        public int CustomerId { get; set; }
        public Customer Customers { get; set; }
        public int ProductId { get; set; }
        public Product Products { get; set; }
        public decimal Price { get; set; }
        public int InvoiceId { get; set; }
        public Invoice invoice { get; set; } 
        public DateTime CreateOn { get; set; }  
    }
}