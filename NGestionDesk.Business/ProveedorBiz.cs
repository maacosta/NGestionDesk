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
    public class ProveedorBiz
    {
        private ProveedorDal proveedorDal;

        public ProveedorBiz()
        {
            this.proveedorDal = FactoryDal<ProveedorDal>.GetDal();
        }

        public void Cargar()
        {
            this.proveedorDal.Cargar();
        }

        public int Agregar(Proveedor proveedor)
        {
            return this.proveedorDal.AgregarEditar(proveedor);
        }

        public List<Proveedor> ObtenerLista()
        {
            return this.proveedorDal.ObtenerLista();
        }
    }
}
