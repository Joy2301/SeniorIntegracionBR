using ExchangeRateAPI1.Infrastructure.Providers;
using System.Net;

namespace ExchangeRateAPI1.Business.Commands
{
    public class ExchangeRateCommandHandler
    {
        private readonly IEnumerable<IExchangeRateProvider> _providers;

        public ExchangeRateCommandHandler(IEnumerable<IExchangeRateProvider> providers)
        {
            _providers = providers;
        }

        public async Task<ExchangeRateCommandDto> HandleAsync(ExchangeRateCommand command)
        {
            var tasks = _providers.Select(p => p.GetRateAsync(command));
            var results = await Task.WhenAll(tasks);

            var best = results
                .Select((rate, index) => new
                {
                    Rate = rate,
                    Provider = _providers.ElementAt(index).Name
                })
                .OrderByDescending(x => x.Rate)
                .First();

            return new ExchangeRateCommandDto
            {
                Rate = best.Rate,
                Provider = best.Provider,
                Total = best.Rate * command.Quantity
            };
        }
    }
}
