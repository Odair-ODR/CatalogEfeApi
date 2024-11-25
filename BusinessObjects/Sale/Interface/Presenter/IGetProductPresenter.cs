using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Services;

namespace BusinessObjects.Sale.Interface.Presenter
{
    public interface IGetProductPresenter
    {
        IResultCommon<List<ProductDto>> Products { get; }
    }
}
