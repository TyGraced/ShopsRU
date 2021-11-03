using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        public bool IsEmployee { get; set; }

        [Required]
        public bool IsAffiliate { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}