using BusinessObjects.Sale.Aggreate;
using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Repository;
using Entities.Models;
using InterfaceAdapters.DataBases;
using InterfaceAdapters.Mapper;
using InterfaceAdapters.Utils;
using Microsoft.Data.SqlClient;
using System.Data;

namespace InterfaceAdapters.Repository
{
    internal class OrderCommandsRepository(
        DBConnectionFactory connectionFactory
        ) : IOrderCommandsRepository
    {

        public async ValueTask CreateOrder(OrderAggregate orderAggregate)
        {
            SqlTransaction? tr = null;
            try
            {
                using SqlConnection cn = connectionFactory.SaleEFE;
                cn.Open();
                tr = cn.BeginTransaction();

                if (!await InsertOrder(tr, orderAggregate))
                {
                    tr.Rollback();
                    return;
                }

                if (!await InsertOrderDetail(tr, orderAggregate))
                {
                    tr.Rollback();
                    return;
                }

                tr.Commit();
            }
            catch
            {
                if (tr?.Connection != null)
                    tr?.Rollback();
                throw;
            }
        }

        private static async ValueTask<bool> InsertOrder(SqlTransaction tr, OrderAggregate orderAggregate)
        {
            const string sentence = "dsp_InsertarOrder";

            using SqlCommand cmd = new(sentence, tr.Connection, tr)
            {
                CommandType = CommandType.StoredProcedure
            };

            _ = cmd.Parameters.AddWithValue("@CustomerId", orderAggregate.CustomerId);
            _ = cmd.Parameters.AddWithValue("@DateOrder", orderAggregate.DateOrder);

            SqlParameter parameter = new("@OrderId", SqlDbType.Int)
            {
                Direction = ParameterDirection.Output
            };

            cmd.Parameters.Add(parameter);

            if (await cmd.ExecuteNonQueryAsync() > 0)
            {
                orderAggregate.OrderId = parameter.Value.ToInt32();
                return true;
            }
            return false;
        }

        private static async ValueTask<bool> InsertOrderDetail(SqlTransaction tr, OrderAggregate orderAggregate)
        {
            const string sentence = "dsp_InsertarOrderDetail";

            if (orderAggregate.OrderDetail.Count == 0) return false;

            foreach (OrderDetailModel item in orderAggregate.OrderDetail)
            {
                using SqlCommand cmd = new(sentence, tr.Connection, tr)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@OrderId", orderAggregate.OrderId);
                _ = cmd.Parameters.AddWithValue("@ProductId", item.ProductId);
                _ = cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                _ = cmd.Parameters.AddWithValue("@Price", item.Price);
                _ = cmd.Parameters.AddWithValue("@Discount", item.DiscountAmount);

                if (await cmd.ExecuteNonQueryAsync() <= 0)
                    return false;
            }
            return true;
        }

        public async ValueTask<List<GetOrderDto>> GetOrder(int customerId)
        {
            try
            {
                const string sentence = "dsp_GetOrderByCustomerId";
                using SqlConnection cn = connectionFactory.SaleEFE;
                cn.Open();
                using SqlCommand cmd = new(sentence, cn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                _ = cmd.Parameters.AddWithValue("@CustomerId", customerId);

                SqlDataReader dr = await cmd.ExecuteReaderAsync();
                return OrderDtoMapper.MapFromDataReaderToGetOrderDto(dr);
            }
            catch
            {
                throw;
            }
        }
    }
}
