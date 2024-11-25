namespace BusinessObjects.Sale.Interface.Port
{
    public interface IGetOrderInpPort
    {
        ValueTask Handle(int customerId);
    }
}
