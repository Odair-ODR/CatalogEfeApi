using BusinessObjects.Sale.DTO;

namespace BusinessObjects.Sale.Interface.Port
{
    public interface IGetOrderOutPort
    {
        void Handle(List<GetOrderDto> to);
    }
}
