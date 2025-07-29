using System.Xml.Serialization;

namespace ExchangeRateOrchestrator.Infrastructure.ApiResponse
{
    [XmlRoot(ElementName = "xml", Namespace = "")]
    public class ExchangeRateApi2Response
    {
        [XmlElement(ElementName = "Result", Namespace = "")]
        public decimal Result { get; set; }
    }
}
