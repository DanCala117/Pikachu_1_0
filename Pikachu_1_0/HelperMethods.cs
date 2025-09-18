using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Zapdos
{
    internal class HelperMethods
    {
        public static T LoadData<T>(string xml)
        {
            var xmlReaderSettings = new XmlReaderSettings() { CheckCharacters = false };
            if (xml == null)
                return default;
            using (StringReader reader = new StringReader(xml))
            using (XmlReader xmlReader = XmlReader.Create(reader, xmlReaderSettings))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                return (T)xs.Deserialize(xmlReader);
            }
        }
    }
}
