using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Services.ExternalServices.Models
{
    [Serializable]
    [XmlRoot("Tarih_Date")]
    public class MainData
    {
        [XmlElement(ElementName = "Currency")]
        public List<Currency> Currencies { get; set; }
        [XmlAttribute(AttributeName = "Tarih")]
        public string Tarih { get; set; }
        [XmlAttribute(AttributeName = "Date")]
        public string Date { get; set; }
        [XmlAttribute(AttributeName = "Bulten_No")]
        public string Bulten_No { get; set; }
    }
}
