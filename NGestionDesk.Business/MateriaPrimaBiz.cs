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
    public class MateriaPrimaBiz
    {
        private MateriaPrimaDal materiaPrimaDal;
        private UnidadBiz unidadBiz;

        public MateriaPrimaBiz()
        {
            this.materiaPrimaDal = FactoryDal<MateriaPrimaDal>.GetDal();
            this.unidadBiz = new UnidadBiz();
        }

        public void Cargar()
        {
            this.materiaPrimaDal.Cargar();
        }

        public int Agregar(MateriaPrima materiaPrima)
        {
            return this.materiaPrimaDal.AgregarEditar(materiaPrima);
        }

        public List<MateriaPrima> ObtenerLista()
        {
            var mpList = this.materiaPrimaDal.ObtenerLista();
            var uList = this.unidadBiz.ObtenerLista();

            mpList.ForEach(i => i.Unidad = uList.FirstOrDefault(ii => ii.Codigo == i.CodigoUnidad));

            return mpList;
        }

        public void Eliminar(MateriaPrima materiaPrima)
        {
            this.materiaPrimaDal.Eliminar(materiaPrima);
        }
    }
}
