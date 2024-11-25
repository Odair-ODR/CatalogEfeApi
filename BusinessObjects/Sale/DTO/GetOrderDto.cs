namespace BusinessObjects.Sale.DTO
{
    public class GetOrderDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<GetOrderDetailDto> OrderDetail { get; set; } = [];
    }

    public class GetOrderDetailDto
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public ProductDto Product { get; set; } = null!;
    }
}
