using ExchangeRateAPI1.Business.Commands;
using ExchangeRateOrchestrator.Infrastructure.ApiResponse;
using System.Net.Http;

namespace ExchangeRateAPI1.Infrastructure.Providers
{
    public class ExchangeRateApi1Provider : IExchangeRateProvider
    {
        private readonly HttpClient _http;
        public string Name => "API1";
        public ExchangeRateApi1Provider(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("http://localhost:5276/");
        }

        public async Task<decimal> GetRateAsync(ExchangeRateCommand command)
        {
            var body = new { from = command.SourceCurrency, to = command.TargetCurrency, value = command.Quantity };

            var response = await _http.PostAsJsonAsync("api1/v1/ExchangeRate", body);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ExchangeRateApi1Response>();
            if (result == null)
                throw new ApplicationException("Invalid response from API 1");

            return result.Rate;
        }
    }
}
