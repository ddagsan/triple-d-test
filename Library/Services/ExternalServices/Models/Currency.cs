using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Services.ExternalServices.Models
{
    [Serializable]
    [XmlRoot(ElementName = "Currency")]
    public class Currency
    {
        [XmlElement(ElementName = "Unit")]
        public string Unit { get; set; }
        [XmlElement(ElementName = "Isim")]
        public string Isim { get; set; }
        [XmlElement(ElementName = "CurrencyName")]
        public string CurrencyName { get; set; }
        [XmlElement(ElementName = "ForexBuying")]
        public string ForexBuyingAsText { get; set; }
        [XmlIgnore]
        public double? ForexBuying { get { return string.IsNullOrEmpty(ForexBuyingAsText) ? (double?)null : double.Parse(ForexBuyingAsText); } }
        [XmlElement(ElementName = "ForexSelling")]
        public string ForexSellingAsText { get; set; }
        [XmlIgnore]
        public double? ForexSelling { get { return string.IsNullOrEmpty(ForexSellingAsText) ? (double?)null : double.Parse(ForexSellingAsText); } }
        [XmlElement(ElementName = "BanknoteBuying")]
        public string BanknoteBuyingAsText { get; set; }
        [XmlIgnore]
        public double? BanknoteBuying { get { return string.IsNullOrEmpty(BanknoteBuyingAsText) ? (double?)null : double.Parse(BanknoteBuyingAsText); } }
        [XmlElement(ElementName = "BanknoteSelling")]
        public string BanknoteSellingAsText { get; set; }
        [XmlIgnore]
        public double? BanknoteSelling { get { return string.IsNullOrEmpty(BanknoteSellingAsText) ? (double?)null : double.Parse(BanknoteSellingAsText); } }
        [XmlElement(ElementName = "CrossRateUSD")]
        public string CrossRateUSDAsText { get; set; }
        [XmlIgnore]
        public double? CrossRateUSD { get { return string.IsNullOrEmpty(CrossRateUSDAsText) ? (double?)null : double.Parse(CrossRateUSDAsText); } }
        [XmlElement(ElementName = "CrossRateOther")]
        public string CrossRateOtherAsText { get; set; }
        [XmlAttribute(AttributeName = "CrossOrder")]
        public string CrossOrder { get; set; }
        [XmlAttribute(AttributeName = "Kod")]
        public string Kod { get; set; }
        [XmlAttribute(AttributeName = "CurrencyCode")]
        public string CurrencyCode { get; set; }
    }
}
