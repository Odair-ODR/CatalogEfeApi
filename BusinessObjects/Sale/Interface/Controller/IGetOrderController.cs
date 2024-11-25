using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Services;

namespace BusinessObjects.Sale.Interface.Controller
{
    public interface IGetOrderController
    {
        ValueTask<IResultCommon<GetOrderDto>> Handle(int customerId);
    }
}
