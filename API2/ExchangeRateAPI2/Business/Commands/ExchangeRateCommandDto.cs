using System.Xml.Serialization;

namespace ExchangeRateAPI1.Business.Commands
{
    [XmlRoot("xml")]
    public class ExchangeRateCommandDto
    {
        [XmlElement("Result")]
        public decimal Result { get; set; }
    }
}
