using BusinessObjects.Sale.Interface.Services;

namespace InterfaceAdapters.Services
{
    internal class ResultCommon<T> : IResultCommon<T>
    {
        private readonly T _value;
        private readonly bool _isSuccess;
        private readonly string _message;

        private ResultCommon(T value, bool isSuccess, string message)
        {
            _value = value;
            _isSuccess = isSuccess;
            _message = message;
        }

        public static IResultCommon<T> Success(T value, string message = "") => new ResultCommon<T>(value, true, message);
        public static IResultCommon<T> Failed(string message) => new ResultCommon<T>(default, false, message);
        public static IResultCommon<T> FailedException(Exception ex) => new ResultCommon<T>(default, false, $"{ex.Message} | {ex.StackTrace}");

        public T Value => _value;
        public bool IsSuccess => _isSuccess;
        public string Message => _message;
    }
}
