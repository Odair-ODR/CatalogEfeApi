namespace BusinessObjects.Sale.DTO
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public ProductDto Product { get; set; } = null!;
        public List<CreateOrderDetailDto> OrderDetail { get; set; }
    }
}
