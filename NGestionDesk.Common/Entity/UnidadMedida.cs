using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NGestionDesk.Common.Entity
{
    public class UnidadMedida
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Factor { get; set; }
        public string CodigoUnidad { get; set; }
        [XmlIgnoreAttribute]
        public Unidad Unidad { get; set; }
    }
}
