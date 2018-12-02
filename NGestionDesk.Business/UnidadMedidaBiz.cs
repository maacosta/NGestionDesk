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
    public class UnidadMedidaBiz
    {
        private List<UnidadMedida> unidades;

        public UnidadMedidaBiz()
        {
            this.unidades = new List<UnidadMedida>()
                {
                    new UnidadMedida() { Codigo = "und", Nombre = "Unidad", CodigoUnidad = "CTD", Factor = 1m },
                    new UnidadMedida() { Codigo = "mg", Nombre = "Miligramo", CodigoUnidad = "MSA", Factor = 1m/1000m },
                    new UnidadMedida() { Codigo = "g", Nombre = "Gramo", CodigoUnidad = "MSA", Factor = 1m },
                    new UnidadMedida() { Codigo = "kg", Nombre = "Kilogramo", CodigoUnidad = "MSA", Factor = 1000m },
                    new UnidadMedida() { Codigo = "mm3", Nombre = "Milimetro cúbico", CodigoUnidad = "VOL", Factor = 1m/1000m },
                    new UnidadMedida() { Codigo = "cm3", Nombre = "Centimetro cúbico", CodigoUnidad = "VOL", Factor = 1m/100m },
                    new UnidadMedida() { Codigo = "dm3", Nombre = "Decimetro cúbico", CodigoUnidad = "VOL", Factor = 1m/10m },
                    new UnidadMedida() { Codigo = "dm3", Nombre = "Metro cúbico", CodigoUnidad = "VOL", Factor = 1m },
                    new UnidadMedida() { Codigo = "ml", Nombre = "Mililitro", CodigoUnidad = "CPD", Factor = 1m/1000m },
                    new UnidadMedida() { Codigo = "cl", Nombre = "Centilitro", CodigoUnidad = "CPD", Factor = 1m/100m },
                    new UnidadMedida() { Codigo = "dl", Nombre = "Decilitro", CodigoUnidad = "CPD", Factor = 1m/10m },
                    new UnidadMedida() { Codigo = "l", Nombre = "Litro", CodigoUnidad = "CPD", Factor = 1m },
                };
        }

        public List<UnidadMedida> ObtenerLista()
        {
            return this.unidades;
        }
    }
}
