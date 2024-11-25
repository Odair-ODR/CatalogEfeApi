namespace BusinessObjects.Sale.DTO
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public BrandDto Brand { get; set; } = new BrandDto();
        public string Description { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public decimal BasePrice { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
    }
}
