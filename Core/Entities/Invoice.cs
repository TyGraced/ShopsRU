using System.Collections.Generic;
using System;

namespace Core.Entities
{
    public class Invoice : BaseEntity
    {
        public decimal TotalAmount { get; set; }
        public List<Product> Product { get; set; }

        public string SellersName { get; set; }
        public string CompanyAddress { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }
     
        public DateTime IssueDate { get; set; }
        public DateTime PaymentDueDate { get; set; }

        public DateTime DeliveryDate { get; set; }
        public int ReferenceNumber { get; set; }

        public ICollection<InvoiceProducts> InvoiceProducts { get; set; }

        public Invoice()
        {
            InvoiceProducts  = new HashSet<InvoiceProducts>();
        }

    }
}