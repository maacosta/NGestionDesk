using NGestionDesk.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGestionDesk.Common.Entity
{
    public class Compra : IEntity
    {
        public int Id { get; set; }
        public DateTime FechaCompra { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaModificacion { get; set; }
        public Proveedor Proveedor { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioTotalConDescuento { get; set; }
        public List<CompraItem> Items { get; set; }
        public int CantidadItems { get { return this.Items != null ? this.Items.Count : 0; } }
        public decimal PrecioTotalCalculado { get { return this.Items != null ? this.Items.Sum(i => i.PrecioUnitario) : 0m; } }
        public decimal PrecioTotalConDescuentoCalculado { get { return this.Items != null ? this.Items.Sum(i => i.PrecioTotalConDescuento) : 0m; } }
    }
}
