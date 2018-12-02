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
        private ProveedorDal proveedorDal;

        public CompraBiz(DateTime fecha)
        {
            this.proveedorDal = FactoryDal<ProveedorDal>.GetDal();
            var aniomes = fecha.Year * 100 + fecha.Month;
            this.compraDal = FactoryDalWithNumber<CompraDal>.GetDal(aniomes);
        }

        public void Cargar()
        {
            this.proveedorDal.Cargar();
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
            var list = this.compraDal.ObtenerLista();
            list.ForEach(i => i.Proveedor = this.proveedorDal.Obtener(i.IdProveedor));
            return list;
        }

        public void Eliminar(Compra compra)
        {
            this.compraDal.Eliminar(compra);
        }
    }
}
