namespace Entities.Models
{
    public class BrandModel
    {
        public int BrandId { get; set; }
        public string Description { get; set; } = string.Empty;
        public string? ShortDescription { get; set; }
        public bool IsActive { get; set; } = true;
        public string CreatorUser { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public string? ModifierUser { get; set; }
        public DateTime? ModificationDate { get; set; }
    }
}
