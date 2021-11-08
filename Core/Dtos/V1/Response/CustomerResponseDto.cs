using System;

namespace API.Dtos.V1.Response
{
    public class CustomerResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public bool IsAffiliate { get; set; }
        public bool IsEmployee { get; set; }
        public DateTime CreatedOn { get; set; }   
    }
}