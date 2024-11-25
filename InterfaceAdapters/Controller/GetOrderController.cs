using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Controller;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Presenter;
using BusinessObjects.Sale.Interface.Services;
using InterfaceAdapters.Services;

namespace InterfaceAdapters.Controller
{
    internal class GetOrderController(
        IGetOrderInpPort orderInpPort,
        IGetOrderPresenter orderPresenter
        ) : IGetOrderController
    {
        public async ValueTask<IResultCommon<GetOrderDto>> Handle(int customerId)
        {
            if (customerId <= 0) return ResultCommon<GetOrderDto>.Failed("CustomerId is required");
            await orderInpPort.Handle(customerId);
            return orderPresenter.Orders;
        }
    }
}
