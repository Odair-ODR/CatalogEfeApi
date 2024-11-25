using BusinessObjects.Sale.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InterfaceAdapters.Mapper
{
    internal static class ProductMapper
    {
        public static List<ProductDto> MapFromDataReaderToProductDto(SqlDataReader dr)
        {
            List<ProductDto> lista = [];
            if (!dr.HasRows) return lista;
            while (dr.Read())
            {
                lista.Add(new ProductDto
                {
                    ProductId = dr.GetInt32("ProductId"),
                    Description = dr.GetString("Description"),
                    ShortDescription = dr.GetString("ShortDescription"),
                    ImgUrl = dr.GetString("ImgUrl"),
                    BasePrice = dr.GetDecimal("BasePrice"),
                    Brand = new BrandDto
                    {
                        Description = dr.GetString("DescBrand")
                    }
                });
            }
            return lista;
        }
    }
}
