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
    public class MarcaBiz
    {
        private MarcaDal marcaDal;

        public MarcaBiz()
        {
            this.marcaDal = FactoryDal<MarcaDal>.GetDal();
        }

        public void Cargar()
        {
            this.marcaDal.Cargar();
        }

        public int Agregar(Marca marca)
        {
            return this.marcaDal.AgregarEditar(marca);
        }

        public List<Marca> ObtenerLista()
        {
            return this.marcaDal.ObtenerLista();
        }
    }
}
