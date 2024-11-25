using BusinessObjects.Sale.DTO;
using Entities.Models;

namespace BusinessObjects.Sale.Aggreate
{
    public class OrderAggregate : OrderModel
    {
        public List<OrderDetailModel> OrderDetail { get; private set; } = [];

        public void AddOrderDetailModel(CreateOrderDetailDto to)
        {
            Add(to);
        }

        public void AddOrderDetailModel(List<CreateOrderDetailDto> list)
        {
            foreach (CreateOrderDetailDto item in list)
            {
                Add(item);
            }
        }

        private void Add(CreateOrderDetailDto to)
        {
            OrderDetailModel? orderDetail = OrderDetail.SingleOrDefault(x => x.ProductId == to.ProductId);
            if (orderDetail == null)
                OrderDetail.Add(new OrderDetailModel
                {
                    ProductId = to.ProductId,
                    Price = to.Price,
                    Quantity = to.Quantity
                });
            else
                orderDetail.Quantity += to.Quantity;
        }

        public static OrderAggregate GetOrderAgregate(CreateOrderDto to)
        {
            OrderAggregate orderAggregate = new()
            {
                CustomerId = to.CustomerId,
            };
            orderAggregate.AddOrderDetailModel(to.OrderDetail);
            return orderAggregate;
        }
    }
}
