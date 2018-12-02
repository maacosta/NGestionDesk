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
    public class Producto : IEntity
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int IdMateriaPrima { get; set; }
        [XmlIgnoreAttribute]
        public MateriaPrima MateriaPrima { get; set; }
        public string CodigoUnidadMedida { get; set; }
        [XmlIgnoreAttribute]
        public UnidadMedida UnidadMedida { get; set; }
        public int Cantidad { get; set; }
        [XmlIgnoreAttribute]
        public Marca Marca { get; set; }
        public int IdMarca { get; set; }
        [XmlIgnoreAttribute]
        public string Nombre 
        { 
            get 
            { 
                string n = null;
                var mp = this.MateriaPrima != null ? this.MateriaPrima.Descripcion : string.Empty;
                var m = this.Marca != null ? this.Marca.Nombre : string.Empty;
                if (!string.IsNullOrEmpty(this.Descripcion))
                    n = string.Format("{0} {1} {2} ({3}{4})", this.Descripcion, mp, m, this.Cantidad, this.CodigoUnidadMedida);
                else
                    n = string.Format("{0} {1} ({2}{3})", mp, m, this.Cantidad, this.CodigoUnidadMedida);
                return n;
            } 
        }
    }
}
