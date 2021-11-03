using System.Collections.Generic;
using System;

namespace Core.Entities
{
    public class Invoice : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public List<Product> Product { get; set; }
        public Customer Customer { get; set; }
        public Discount Discount { get; set; }
        public DateTime Date { get; set; }
    }
}