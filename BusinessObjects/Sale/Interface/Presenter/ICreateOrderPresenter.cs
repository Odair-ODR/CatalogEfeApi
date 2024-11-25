using BusinessObjects.Sale.Interface.Services;

namespace BusinessObjects.Sale.Interface.Presenter
{
    public interface ICreateOrderPresenter
    {
        IResultCommon<int> OrderId { get; }
    }
}
