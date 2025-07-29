namespace ExchangeRateAPI1.Infrastructure.Providers
{
    public class ExchangeRateProvider : IExchangeRateProvider
    {
        private static readonly Dictionary<(string From, string To), decimal> _rates = new()
        {
            { ("USD", "DOP"), 58.5m },
            { ("USD", "EUR"), 0.91m },
            { ("DOP", "USD"), 0.0171m },
            { ("DOP", "EUR"), 0.0156m },
            { ("EUR", "USD"), 1.15m },
            { ("EUR", "DOP"), 63.3m }
        };
        public Task<decimal> GetRateAsync(string from, string to)
        {
            var key = (from.ToUpper(), to.ToUpper());
            if (_rates.TryGetValue(key, out var rate))
                return Task.FromResult(rate);

            throw new KeyNotFoundException($"No conversion rate found for {from} → {to}");
        }
    }
}
