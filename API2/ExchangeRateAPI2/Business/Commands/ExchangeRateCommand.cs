using System.Xml.Serialization;

namespace ExchangeRateAPI1.Business.Commands
{
    [XmlRoot("xml")]
    public class ExchangeRateCommand
    {
        [XmlElement("from")]
        public string From { get; set; } = string.Empty;

        [XmlElement("to")]
        public string To { get; set; } = string.Empty;

        [XmlElement("amount")]
        public decimal Amount { get; set; }
    }
}
