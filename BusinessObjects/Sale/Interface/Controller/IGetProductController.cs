using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Services;

namespace BusinessObjects.Sale.Interface.Controller
{
    public interface IGetProductController
    {
        ValueTask<IResultCommon<List<ProductDto>>> GetProducts();
    }
}
