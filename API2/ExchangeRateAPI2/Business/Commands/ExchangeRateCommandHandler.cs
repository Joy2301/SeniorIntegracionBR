using ExchangeRateAPI1.Infrastructure.Providers;
using System.Net;

namespace ExchangeRateAPI1.Business.Commands
{
    public class ExchangeRateCommandHandler
    {
        private readonly IExchangeRateProvider _provider;
        public ExchangeRateCommandHandler(IExchangeRateProvider provider)
        {
            _provider = provider;
        }

        public async Task<ExchangeRateCommandDto> HandleAsync(ExchangeRateCommand command)
        {
            try
            {
                var rate = await _provider.GetRateAsync(command.From, command.To);
                return new ExchangeRateCommandDto
                {
                    Result = rate * command.Amount
                };
            }
            catch (KeyNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Error calculating exchange rate.", ex);
            }
        }
    }
}
