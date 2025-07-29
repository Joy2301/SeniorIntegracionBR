namespace ExchangeRateAPI1.Infrastructure.Providers
{
    public class ExchangeRateProvider : IExchangeRateProvider
    {
        private static readonly Dictionary<(string From, string To), decimal> _results = new()
        {
            { ("USD", "DOP"), 59.5m },
            { ("USD", "EUR"), 0.97m },
            { ("DOP", "USD"), 0.0182m },
            { ("DOP", "EUR"), 0.0166m },
            { ("EUR", "USD"), 1.15m },
            { ("EUR", "DOP"), 64.3m }
        };
        public Task<decimal> GetRateAsync(string from, string to)
        {
            var key = (from.ToUpper(), to.ToUpper());
            if (_results.TryGetValue(key, out var rate))
                return Task.FromResult(rate);

            throw new KeyNotFoundException($"No conversion rate found for {from} → {to}");
        }
    }
}
