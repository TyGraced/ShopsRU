using System;

namespace Core.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public bool IsAffiliate { get; set; }
        public bool IsEmployee { get; set; }
        public DateTime CreatedOn { get; set; }
    }

}