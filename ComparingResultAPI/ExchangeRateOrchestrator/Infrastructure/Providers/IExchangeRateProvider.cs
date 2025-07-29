using ExchangeRateAPI1.Business.Commands;

namespace ExchangeRateAPI1.Infrastructure.Providers
{
    public interface IExchangeRateProvider
    {
        string Name { get; }
        Task<decimal> GetRateAsync(ExchangeRateCommand command);
    }
}
