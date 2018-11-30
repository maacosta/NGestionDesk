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

        public MateriaPrimaBiz()
        {
            this.materiaPrimaDal = FactoryDal<MateriaPrimaDal>.GetDal();
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
            return this.materiaPrimaDal.ObtenerLista();
        }

        public void Eliminar(MateriaPrima materiaPrima)
        {
            this.materiaPrimaDal.Eliminar(materiaPrima);
        }
    }
}
