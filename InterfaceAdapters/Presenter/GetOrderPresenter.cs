using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Presenter;
using BusinessObjects.Sale.Interface.Services;
using InterfaceAdapters.Services;

namespace InterfaceAdapters.Presenter
{
    internal class GetOrderPresenter : IGetOrderPresenter, IGetOrderOutPort
    {
        public IResultCommon<GetOrderDto> Orders { get; private set; } = null!;

        public void Handle(List<GetOrderDto> to)
        {
            GetOrderDto order = new();
            GetOrderDetailDto? detailDto = null;
            foreach (GetOrderDto item in to)
            {
                foreach (GetOrderDetailDto detail in item.OrderDetail)
                {
                    detailDto = order.OrderDetail.SingleOrDefault(x => x.Product.ProductId == detail.Product.ProductId);
                    if (detailDto == null)
                        order.OrderDetail.Add(detail);
                    else
                    {
                        detailDto.Quantity += detail.Quantity;
                    }
                }
            }
            Orders = ResultCommon<GetOrderDto>.Success(order);
        }
    }
}
