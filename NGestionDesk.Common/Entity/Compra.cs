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
    public class Compra : IEntity
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        [XmlIgnoreAttribute]
        public Proveedor Proveedor { get; set; }
        public int IdProveedor { get; set; }
        public List<CompraItem> Items { get; set; }
        public int CantidadItems { get { return this.Items != null ? this.Items.Count : 0; } }
        [XmlIgnoreAttribute]
        public decimal PrecioTotal { get { return this.Items != null ? this.Items.Sum(i => i.PrecioUnitario * i.Cantidad) : 0m; } }
        [XmlIgnoreAttribute]
        public decimal PrecioTotalConDescuento { get { return this.Items != null ? this.Items.Sum(i => i.PrecioTotalConDescuento) : 0m; } }
    }
}
