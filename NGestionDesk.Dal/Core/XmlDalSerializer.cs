using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace NGestionDesk.Dal.Core
{
    public class XmlDalSerializer
    {
        private string filePath;

        public XmlDalSerializer(string filePath)
        {
            this.filePath = filePath;
        }

        public void Save<T>(T value)
        {
            using (var writer = new StreamWriter(this.filePath))
            {
                var serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, value);
                writer.Flush();
            }
        }

        public T Load<T>()
        {
            if(!File.Exists(this.filePath))
            {
                return default(T);
            }
            using (var stream = File.OpenRead(this.filePath))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(stream);
            }
        }
    }
}
