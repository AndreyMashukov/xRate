using System.Collections.Generic;
using System.Xml.Serialization;

namespace xRate.Model
{
    [XmlRoot("ValCurs")]
    public class ValCurs
    {
        [XmlElement("Valute")]
        public List<Valute> list { get; set; }
    }
}