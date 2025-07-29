namespace ExchangeRateAPI1.Business.Commands
{
    public class ExchangeRateCommand
    {
        public string SourceCurrency { get; set; } = string.Empty;
        public string TargetCurrency { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
    }
}
