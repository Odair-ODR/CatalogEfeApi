using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Services;

namespace BusinessObjects.Sale.Interface.Controller
{
    public interface ICreateOrderController
    {
        ValueTask<IResultCommon<int>> Handle(CreateOrderDto to);
    }
}
