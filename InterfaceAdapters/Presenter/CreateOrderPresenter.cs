using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Presenter;
using BusinessObjects.Sale.Interface.Services;
using InterfaceAdapters.Services;

namespace InterfaceAdapters.Port
{
    internal class CreateOrderPresenter : ICreateOrderPresenter, ICreateOrderOutPort
    {
        public IResultCommon<int> OrderId { get; private set; } = null!;

        public ValueTask Handle(int orderId)
        {
            try
            {
                if (orderId > 0)
                    OrderId = ResultCommon<int>.Success(orderId);
                else
                    OrderId = ResultCommon<int>.Failed("Error to save orders");
            }
            catch (Exception ex)
            {
                OrderId = ResultCommon<int>.FailedException(ex);
            }
            return ValueTask.CompletedTask;
        }
    }
}
