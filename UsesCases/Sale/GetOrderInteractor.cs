using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Repository;

namespace UsesCases.Sale
{
    public class GetOrderInteractor(
        IOrderCommandsRepository commandsRepository,
        IGetOrderOutPort orderOutPort
        ) : IGetOrderInpPort
    {
        public async ValueTask Handle(int customerId)
        {
            try
            {
                List<GetOrderDto> orderDto = await commandsRepository.GetOrder(customerId);
                orderOutPort.Handle(orderDto);
            }
            catch
            {
                throw;
            }
        }
    }
}
