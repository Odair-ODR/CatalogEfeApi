using BusinessObjects.Sale.DTO;

namespace BusinessObjects.Sale.Interface.Port
{
    public interface IGetProductOutPort
    {
        void Handle(List<ProductDto> products);
    }
}
