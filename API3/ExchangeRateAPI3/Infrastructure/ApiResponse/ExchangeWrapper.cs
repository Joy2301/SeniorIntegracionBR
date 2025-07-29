using ExchangeRateAPI1.Business.Commands;

namespace ExchangeRateAPI3.Infrastructure.ApiResponse
{
    public class ExchangeWrapper
    {
        public ExchangeRateCommandDto Exchange { get; set; } = new();
    }
}
