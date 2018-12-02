using NGestionDesk.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NGestionDesk.Common.Entity
{
    [Serializable]
    public class MateriaPrima : IEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string CodigoUnidad { get; set; }
        [XmlIgnoreAttribute]
        public Unidad Unidad { get; set; }
    }
}
