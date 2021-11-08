namespace Core.Dtos.V1.Response
{
    public class InvoiceCustomerDto
    {
        public int CustomerId { get; set; }
        public bool IsAffiliate { get; set; }
        public bool IsEmployee { get; set; }
        public int OverTwoYears { get; set; }
    }
}
