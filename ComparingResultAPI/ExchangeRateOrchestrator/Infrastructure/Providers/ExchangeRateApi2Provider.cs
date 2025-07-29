using ExchangeRateAPI1.Business.Commands;
using ExchangeRateAPI1.Infrastructure.Providers;
using ExchangeRateOrchestrator.Infrastructure.ApiResponse;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;

namespace ExchangeRateOrchestrator.Infrastructure.Providers
{
    public class ExchangeRateApi2Provider : IExchangeRateProvider
    {
        private readonly HttpClient _http;
        public string Name => "API2";
        public ExchangeRateApi2Provider(HttpClient http)
        {
            _http = http;
            _http.BaseAddress = new Uri("http://localhost:5275/");
        }

        public async Task<decimal> GetRateAsync(ExchangeRateCommand command)
        {
            var xml = $@"
            <ExchangeRateCommand>
              <from>{command.SourceCurrency}</from>
              <to>{command.TargetCurrency}</to>
              <amount>{command.Quantity}</amount>
            </ExchangeRateCommand>";

            var content = new StringContent(xml, Encoding.UTF8, "application/xml");

            var response = await _http.PostAsync("api2/v1/ExchangeRate", content);
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ExchangeResponse<decimal>>();
            if (result?.Data == null)
                throw new ApplicationException("Invalid XML response from API 2");

            return result.Data.Total;
        }
    }
}
