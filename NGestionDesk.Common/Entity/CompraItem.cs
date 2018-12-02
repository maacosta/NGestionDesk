using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NGestionDesk.Common.Entity
{
    [Serializable]
    public class CompraItem
    {
        [XmlIgnoreAttribute]
        public Producto PresentacionMateriaPrima { get; set; }
        public int IdPresentacionMateriaPrima { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioTotalConDescuento { get; set; }
    }
}
