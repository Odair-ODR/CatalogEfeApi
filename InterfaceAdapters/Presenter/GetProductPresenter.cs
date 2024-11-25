using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Presenter;
using BusinessObjects.Sale.Interface.Services;
using InterfaceAdapters.Services;

namespace InterfaceAdapters.Presenter
{
    internal class GetProductPresenter : IGetProductPresenter, IGetProductOutPort
    {
        public IResultCommon<List<ProductDto>> Products { get; private set; } = null!;

        public void Handle(List<ProductDto> products)
        {
            Products = ResultCommon<List<ProductDto>>.Success(products);
        }
    }
}
