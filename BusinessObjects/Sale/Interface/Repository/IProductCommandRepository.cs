using BusinessObjects.Sale.DTO;

namespace BusinessObjects.Sale.Interface.Repository
{
    public interface IProductCommandRepository
    {
        ValueTask<List<ProductDto>> GetProducts();
    }
}
