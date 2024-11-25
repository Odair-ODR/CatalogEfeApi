using BusinessObjects.Sale.DTO;

namespace BusinessObjects.Sale.Interface.Port
{
    public interface ICreateOrderInpPort
    {
        ValueTask Handle(CreateOrderDto to);
    }
}
