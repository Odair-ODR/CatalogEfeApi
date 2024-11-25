using BusinessObjects.Sale.Interface.Port;
using Microsoft.Extensions.DependencyInjection;
using UsesCases.Sale;

namespace UsesCases
{
    public static class Dependencies
    {
        public static IServiceCollection AddApplicationBussinesRules(this IServiceCollection service)
        {
            service.AddScoped<ICreateOrderInpPort, CreateOrderInteractor>();
            service.AddScoped<IGetOrderInpPort, GetOrderInteractor>();
            service.AddScoped<IGetProductInpPort, GetProductInteractor>();
            return service;
        }
    }
}
