namespace ExchangeRateAPI1.Business.Commands
{
    public class ExchangeRateCommandDto
    {
        public decimal Total { get; set; }
        public string Provider { get; set; } = string.Empty;
        public decimal Rate { get; set; }
    }
}
