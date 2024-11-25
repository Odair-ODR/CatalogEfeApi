using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Repository;
using InterfaceAdapters.DataBases;
using InterfaceAdapters.Mapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InterfaceAdapters.Repository
{
    internal class ProductCommandRepository(
        DBConnectionFactory connectionFactory
        ) : IProductCommandRepository
    {
        public async ValueTask<List<ProductDto>> GetProducts()
        {
            try
            {
                const string sentence = "dsp_GetProducts";
                using SqlConnection cn = connectionFactory.SaleEFE;
                cn.Open();
                using SqlCommand cmd = new(sentence, cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return ProductMapper.MapFromDataReaderToProductDto(dr);
            }
            catch
            {
                throw;
            }
        }
    }
}
