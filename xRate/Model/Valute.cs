using System;
using System.Xml.Serialization;

namespace xRate.Model
{
    public class Valute
    {
        [XmlElement("NumCode")]
        public String NumCode { get; set; }
        
        [XmlElement("Nominal")]
        public String Nominal { get; set; }
        
        [XmlElement("Value")]
        public String Value { get; set; }
        
        [XmlElement("Name")]
        public String Name { get; set; }
        
        [XmlElement("CharCode")]
        public String CharCode { get; set; }
    }
}