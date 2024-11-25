namespace BusinessObjects.Sale.Interface.Port
{
    public interface ICreateOrderOutPort
    {
        ValueTask Handle(int orderId);
    }
}
