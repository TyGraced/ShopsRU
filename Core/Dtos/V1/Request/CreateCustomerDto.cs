using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.V1.Request
{
    public class CreateCustomerDto
    {
        
        [Required]
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public bool IsAffiliate { get; set; }

        [Required]
        public bool IsEmployee { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}