namespace ExchangeRateOrchestrator.Infrastructure.ApiResponse
{
    public class ExchangeInner
    {
        public string SourceCurrency { get; set; } = string.Empty;
        public string TargetCurrency { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
    }
}
