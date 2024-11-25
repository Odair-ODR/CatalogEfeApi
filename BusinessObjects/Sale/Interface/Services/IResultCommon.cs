namespace BusinessObjects.Sale.Interface.Services
{
    public interface IResultCommon<T>
    {
        public T Value { get; }
        public bool IsSuccess { get; }
        public string Message { get; }
    }
}
