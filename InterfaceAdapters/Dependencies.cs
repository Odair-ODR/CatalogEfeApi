using BusinessObjects.Sale.Interface.Controller;
using BusinessObjects.Sale.Interface.Port;
using BusinessObjects.Sale.Interface.Presenter;
using BusinessObjects.Sale.Interface.Repository;
using InterfaceAdapters.Controller;
using InterfaceAdapters.DataBases;
using InterfaceAdapters.Port;
using InterfaceAdapters.Presenter;
using InterfaceAdapters.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace InterfaceAdapters
{
    public static class Dependencies
    {
        public static IServiceCollection AddInterfaceAdapterServices(this IServiceCollection service)
        {
            service.AddSingleton<DBConnectionFactory>();

            service.AddScoped<IOrderCommandsRepository, OrderCommandsRepository>();
            service.AddScoped<CreateOrderPresenter>();
            service.AddScoped<ICreateOrderOutPort>((provider) => provider.GetService<CreateOrderPresenter>()!);
            service.AddScoped<ICreateOrderPresenter>((provider) => provider.GetService<CreateOrderPresenter>()!);
            service.AddScoped<ICreateOrderController, CreateOrderController>();
            service.AddScoped<GetOrderPresenter>();
            service.AddScoped<IGetOrderOutPort>((provider) => provider.GetService<GetOrderPresenter>()!);
            service.AddScoped<IGetOrderPresenter>((provider) => provider.GetService<GetOrderPresenter>()!);
            service.AddScoped<IGetOrderController, GetOrderController>();

            service.AddScoped<IProductCommandRepository, ProductCommandRepository>();
            service.AddScoped<GetProductPresenter>();
            service.AddScoped<IGetProductOutPort>((provider) => provider.GetService<GetProductPresenter>()!);
            service.AddScoped<IGetProductPresenter>((provider) => provider.GetService<GetProductPresenter>()!);
            service.AddScoped<IGetProductController, GetProductController>();

            return service;
        }
    }
}
