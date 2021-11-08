namespace Core.Dtos.V1.Response
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public decimal Price { get; set; }

        public bool IsGrocery { get; set; }
    }
}
