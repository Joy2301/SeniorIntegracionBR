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
            var tasks = _providers.Select(async provider =>
            {
                try
                {
                    var rate = await provider.GetRateAsync(command);
                    return new
                    {
                        Success = true,
                        Rate = rate,
                        Provider = provider.Name
                    };
                }
                catch
                {
                    return new
                    {
                        Success = false,
                        Rate = 0m,
                        Provider = provider.Name
                    };
                }
            });

            var results = await Task.WhenAll(tasks);

            var validResults = results.Where(x => x.Success && x.Rate > 0).OrderByDescending(x => x.Rate).ToList();

            if (!validResults.Any())
                throw new ApplicationException("No provider responded successfully.");

            var best = validResults.First();

            return new ExchangeRateCommandDto
            {
                Rate = best.Rate,
                Provider = best.Provider,
                Total = best.Rate * command.Quantity
            };
        }
    }
}
