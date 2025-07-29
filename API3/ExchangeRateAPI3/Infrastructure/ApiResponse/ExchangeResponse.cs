namespace ExchangeRateAPI3.Infrastructure.ApiResponse
{
    public class ExchangeResponse<T>
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = "OK";
        public object Data { get; set; } = default!;
    }
}
