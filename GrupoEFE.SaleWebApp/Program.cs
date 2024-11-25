namespace GrupoEFE.SaleWebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args).CreateApplication();
            var app = builder.Build();
            app.ConfigureWebApplication();
            app.Run();
        }
    }
}
