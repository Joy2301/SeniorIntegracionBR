using ExchangeRateAPI1.Business.Commands;
using ExchangeRateAPI1.Infrastructure.Providers;
using ExchangeRateOrchestrator.Infrastructure.ApiResponse;
using System.Net.Http;
using System.Text;
using System.Xml;
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
            var xml = $@"<xml>
                            <from>{command.SourceCurrency}</from>
                            <to>{command.TargetCurrency}</to>
                            <amount>{command.Quantity}</amount>
                        </xml>";

            var content = new StringContent(xml, Encoding.UTF8, "application/xml");
            var response = await _http.PostAsync("api2/v1/ExchangeRate", content);
            response.EnsureSuccessStatusCode();

            await using var stream = await response.Content.ReadAsStreamAsync();

            var serializer = new XmlSerializer(typeof(ExchangeRateApi2Response));

            // Esto fuerza ignorar namespaces
            var settings = new XmlReaderSettings { Async = true };
            using var reader = XmlReader.Create(stream, settings);
            var result = (ExchangeRateApi2Response?)serializer.Deserialize(reader);

            if (result == null)
                throw new ApplicationException("Invalid XML response from API 2");

            return result.Result;
        }
    }
}
