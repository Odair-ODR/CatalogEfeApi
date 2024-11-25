using BusinessObjects.Sale.Aggreate;
using BusinessObjects.Sale.DTO;

namespace BusinessObjects.Sale.Interface.Repository
{
    public interface IOrderCommandsRepository
    {
        ValueTask CreateOrder(OrderAggregate orderAggregate);
        ValueTask<List<GetOrderDto>> GetOrder(int customerId);
    }
}
