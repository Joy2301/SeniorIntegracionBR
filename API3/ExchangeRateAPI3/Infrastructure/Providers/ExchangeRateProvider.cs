namespace ExchangeRateAPI1.Infrastructure.Providers
{
    public class ExchangeRateProvider : IExchangeRateProvider
    {
        private static readonly Dictionary<(string sourceCurrency, string TargetCurrency), decimal> _rates = new()
        {
            { ("USD", "DOP"), 55.5m },
            { ("USD", "EUR"), 0.86m },
            { ("DOP", "USD"), 0.0134m },
            { ("DOP", "EUR"), 0.0179m },
            { ("EUR", "USD"), 1.20m },
            { ("EUR", "DOP"), 69.3m }
        };
        public Task<decimal> GetRateAsync(string sourceCurrency, string TargetCurrency)
        {
            var key = (sourceCurrency.ToUpper(), TargetCurrency.ToUpper());
            if (_rates.TryGetValue(key, out var rate))
                return Task.FromResult(rate);

            throw new KeyNotFoundException($"No conversion rate found for {sourceCurrency} → {TargetCurrency}");
        }
    }
}
