using BusinessObjects.Sale.DTO;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InterfaceAdapters.Mapper
{
    public static class OrderDtoMapper
    {
        public static List<GetOrderDto> MapFromDataReaderToGetOrderDto(SqlDataReader dr)
        {
            List<GetOrderDto> lista = [];
            if (!dr.HasRows) return lista;
            while (dr.Read())
            {
                GetOrderDto? order = lista.SingleOrDefault(x => x.OrderId == dr.GetInt32("OrderId"));
                if (order == null)
                {
                    order = new GetOrderDto
                    {
                        OrderId = dr.GetInt32("OrderId"),
                        CustomerId = dr.GetInt32("CustomerId"),
                    };
                    AddGetOrderDetailDto(order, dr);
                }
                else
                {
                    AddGetOrderDetailDto(order, dr);
                }
                lista.Add(order);
            }
            return lista;
        }

        private static void AddGetOrderDetailDto(GetOrderDto order, SqlDataReader dr)
        {
            order.OrderDetail.Add(new GetOrderDetailDto
            {
                Quantity = dr.GetInt32("Quantity"),
                Discount = Convert.ToSingle(dr["Discount"]),
                Product = new ProductDto
                {
                    ProductId = dr.GetInt32("ProductId"),
                    Description = dr.GetString("DescProduct"),
                    BasePrice = dr.GetDecimal("BasePrice"),
                    Brand = new BrandDto
                    {
                        Description = dr.GetString("DescBrand")
                    }
                }
            });
        }
    }
}
