using Entities.Types;

namespace Entities.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime DateOrder { get; set; } = DateTime.Now;
    }

    public class OrderDetailModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public bool IsActive { get; set; } = true;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public DiscountType DiscountType { get; set; } = DiscountType.Nothing;
        public float DiscountAmount { get => DiscountType == DiscountType.Nothing ? 0 : throw new Exception("Not implement option"); }
    }
}
