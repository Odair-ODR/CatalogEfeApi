namespace Entities.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public BrandModel Brand { get; set; } = new BrandModel();
        public CategoryModel Category { get; set; } = new CategoryModel();
        public string Description { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public decimal BasePrice { get; set; }
        public string ImgUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public string CreatorUser { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? ModifierUser { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
