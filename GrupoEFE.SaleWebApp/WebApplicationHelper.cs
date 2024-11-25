using GrupoEFE.SaleWebApp.Endpoints;
using InterfaceAdapters;
using UsesCases;

namespace GrupoEFE.SaleWebApp
{
    public static class WebApplicationHelper
    {
        public static WebApplicationBuilder CreateApplication(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(option =>
            {
                option.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services
                .AddInterfaceAdapterServices()
                .AddApplicationBussinesRules();
            return builder;
        }

        public static WebApplication ConfigureWebApplication(this WebApplication app)
        {
            app.UseCors("AllowAll");
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapGet("/", () => "Hello World!!!");
            var apiGroup = app.MapGroup("/api");
            apiGroup.RegisterSaleEndpoints();
            return app;
        }
    }
}
