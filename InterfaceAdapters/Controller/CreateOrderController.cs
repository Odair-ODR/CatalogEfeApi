using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Controller;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Presenter;
using BusinessObjects.Sale.Interface.Services;
using InterfaceAdapters.Services;

namespace InterfaceAdapters.Controller
{
    internal class CreateOrderController(
        ICreateOrderInpPort createOrderInpPort,
        ICreateOrderPresenter createOrderPresenter
        ) : ICreateOrderController
    {
        public async ValueTask<IResultCommon<int>> Handle(CreateOrderDto to)
        {
            try
            {
                await createOrderInpPort.Handle(to);
                return createOrderPresenter.OrderId;
            }
            catch (Exception ex)
            {
                return ResultCommon<int>.FailedException(ex);
            }
        }
    }
}
