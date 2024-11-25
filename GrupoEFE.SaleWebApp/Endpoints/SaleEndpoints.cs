using BusinessObjects.Sale.DTO;
using BusinessObjects.Sale.Interface.Controller;
using BusinessObjects.Sale.Interface.Services;
using GrupoEFE.SaleWebApp.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GrupoEFE.SaleWebApp.Endpoints
{
    public static class SaleEndpoints
    {
        public static RouteGroupBuilder RegisterSaleEndpoints(this RouteGroupBuilder app)
        {
            app.MapPost("/cart", CreateOrder);
            app.MapGet("/cart/{customerId}", GetOrders);
            app.MapGet("/products", GetProducts);
            return app;
        }

        private static async Task<Results<Ok<ApiResponseModel>, NotFound>> CreateOrder([FromBody] CreateOrderDto to, ICreateOrderController controller)
        {
            IResultCommon<int> result = await controller.Handle(to);
            return TypedResults.Ok(new ApiResponseModel(result.IsSuccess, result.Value, result.Message));
        }

        private static async Task<Results<Ok<ApiResponseModel>, NotFound>> GetOrders(int customerId, IGetOrderController controller)
        {
            IResultCommon<GetOrderDto> result = await controller.Handle(customerId);
            return TypedResults.Ok(new ApiResponseModel(result.IsSuccess, result.Value, result.Message));
        }

        private static async Task<Results<Ok<ApiResponseModel>, NotFound>> GetProducts(IGetProductController controller)
        {
            IResultCommon<List<ProductDto>> result = await controller.GetProducts();
            return TypedResults.Ok(new ApiResponseModel(result.IsSuccess, result.Value, result.Message));
        }
    }
}
