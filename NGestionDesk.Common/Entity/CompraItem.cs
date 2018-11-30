using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGestionDesk.Common.Entity
{
    public class CompraItem
    {
        public Marca Marca { get; set; }
        public MateriaPrima MateriaPrima { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal PrecioTotal { get; set; }
        public decimal PrecioTotalConDescuento { get; set; }
    }
}
