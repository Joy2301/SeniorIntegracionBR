namespace ExchangeRateAPI1.Infrastructure.Providers
{
    public interface IExchangeRateProvider
    {
        Task<decimal> GetRateAsync(string from, string to);
    }
}
