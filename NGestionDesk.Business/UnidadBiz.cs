using NGestionDesk.Common.Entity;
using NGestionDesk.Dal;
using NGestionDesk.Dal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGestionDesk.Business
{
    public class UnidadBiz
    {
        private List<Unidad> unidades;

        public UnidadBiz()
        {
            this.unidades = new List<Unidad>()
                {
                    new Unidad() { Codigo = "CTD", Nombre = "Cantidad" },
                    new Unidad() { Codigo = "MSA", Nombre = "Masa" },
                    new Unidad() { Codigo = "VOL", Nombre = "Volumen" },
                    new Unidad() { Codigo = "CPD", Nombre = "Capacidad" },
                };
        }

        public List<Unidad> ObtenerLista()
        {
            return this.unidades;
        }
    }
}
