namespace ExchangeRateOrchestrator.Infrastructure.ApiResponse
{
    public class ExchangeResponse<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public DataWrapper<T> Data { get; set; } = default!;
    }
    public class DataWrapper<T>
    {
        public T Total { get; set; }
    }
}
