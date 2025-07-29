using ExchangeRateAPI1.Business.Commands;
using ExchangeRateAPI1.Infrastructure.Providers;
using ExchangeRateOrchestrator.Infrastructure.ApiResponse;
using System.Net.Http;
using System.Xml.Serialization;

namespace ExchangeRateOrchestrator.Infrastructure.Providers
{
    public class ExchangeRateApi3Provider : IExchangeRateProvider
    {
        private readonly HttpClient _http;
        public string Name => "API3";
        public ExchangeRateApi3Provider(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("http://localhost:5274/");
        }

        public async Task<decimal> GetRateAsync(ExchangeRateCommand command)
        {
            var body = new
            {
                sourceCurrency = command.SourceCurrency,
                targetCurrency = command.TargetCurrency,
                quantity = command.Quantity
            };

        var response = await _http.PostAsJsonAsync("api3/v1/ExchangeRate", body);
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadFromJsonAsync<ExchangeResponse<decimal>>();
        if (result?.Data == null)
            throw new ApplicationException("Invalid response from API 3");

        return result.Data.Total;
        }
    }
}
