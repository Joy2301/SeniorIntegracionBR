namespace ExchangeRateOrchestrator.Infrastructure.ApiResponse
{
    public class ExchangeRateApi3Response
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;
        public decimal Data { get; set; }
    }
}
