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
    public class CompraBiz
    {
        private CompraDal compraDal;

        public CompraBiz(DateTime fecha)
        {
            var aniomes = fecha.Year * 100 + fecha.Month;
            this.compraDal = FactoryDalWithNumber<CompraDal>.GetDal(aniomes);
        }

        public void Cargar()
        {
            this.compraDal.Cargar();
        }

        public int AgregarEditar(Compra compra)
        {
            if(compra.Id == 0)
            {
                compra.FechaCreacion = DateTime.Now;
            }
            else
            {
                compra.FechaModificacion = DateTime.Now;
            }
            return this.compraDal.AgregarEditar(compra);
        }

        public List<Compra> ObtenerLista()
        {
            return this.compraDal.ObtenerLista();
        }

        public void Eliminar(Compra compra)
        {
            this.compraDal.Eliminar(compra);
        }
    }
}
