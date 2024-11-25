using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Repository;

namespace UsesCases.Sale
{
    public class GetProductInteractor(
        IProductCommandRepository productCommand,
        IGetProductOutPort productOutPort
        ) : IGetProductInpPort
    {
        public async ValueTask Handle()
        {
            List<ProductDto> products = await productCommand.GetProducts();
            productOutPort.Handle(products);
        }
    }
}
