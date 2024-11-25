using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Controller;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Presenter;
using BusinessObjects.Sale.Interface.Services;

namespace InterfaceAdapters.Controller
{
    public class GetProductController(
        IGetProductInpPort productInpPort,
        IGetProductPresenter productPresenter
        ) : IGetProductController
    {
        public async ValueTask<IResultCommon<List<ProductDto>>> GetProducts()
        {
            await productInpPort.Handle();
            return productPresenter.Products;
        }
    }
}
