namespace BusinessObjects.Sale.DTO
{
    public class CreateOrderDetailDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
