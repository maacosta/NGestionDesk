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
                    new Unidad() { Nombre = "Unidad", Abreviacion = "und" },
                    new Unidad() { Nombre = "Gramo", Abreviacion = "gr" },
                    new Unidad() { Nombre = "Kilogramo", Abreviacion = "kg" },
                    new Unidad() { Nombre = "Centimetros cubicos", Abreviacion = "cc" },
                    new Unidad() { Nombre = "Litro", Abreviacion = "lt" },
                };
        }

        public List<Unidad> ObtenerLista()
        {
            return this.unidades;
        }
    }
}
