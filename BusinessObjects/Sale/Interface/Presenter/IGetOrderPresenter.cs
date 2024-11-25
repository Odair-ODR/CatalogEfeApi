using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Services;

namespace BusinessObjects.Sale.Interface.Presenter
{
    public interface IGetOrderPresenter
    {
        IResultCommon<GetOrderDto> Orders { get; }
    }
}
