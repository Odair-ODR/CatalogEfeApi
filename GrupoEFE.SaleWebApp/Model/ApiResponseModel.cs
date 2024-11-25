namespace GrupoEFE.SaleWebApp.Model
{
    public class ApiResponseModel(bool success, object? data, string? message = "")
    {
        public bool Success { get; private set; } = success;
        public string? Message { get; private set; } = message;
        public object? Data { get; private set; } = data;
    }
}
