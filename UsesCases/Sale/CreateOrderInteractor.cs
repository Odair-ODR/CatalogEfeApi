using BusinessObjects.Sale.Aggreate;
using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Repository;

namespace UsesCases.Sale
{
    public class CreateOrderInteractor(
        IOrderCommandsRepository orderCommandRepository,
        ICreateOrderOutPort createOrderOutPort
        ) : ICreateOrderInpPort
    {
        private readonly IOrderCommandsRepository _orderCommandRepository = orderCommandRepository;
        private readonly ICreateOrderOutPort _createOrderOutPort = createOrderOutPort;

        public async ValueTask Handle(CreateOrderDto to)
        {
            try
            {
                OrderAggregate orderAggregate = OrderAggregate.GetOrderAgregate(to);
                await _orderCommandRepository.CreateOrder(orderAggregate);
                await _createOrderOutPort.Handle(orderAggregate.OrderId);
            }
            catch
            {
                throw;
            }
        }
    }
}
