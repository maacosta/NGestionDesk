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
    public class ProductoBiz
    {
        private ProductoDal productoDal;
        private MateriaPrimaDal materiaPrimaDal;
        private MarcaDal marcaDal;
        private UnidadMedidaBiz unidadMedidaBiz;

        public ProductoBiz()
        {
            this.productoDal = FactoryDal<ProductoDal>.GetDal();
            this.materiaPrimaDal = FactoryDal<MateriaPrimaDal>.GetDal();
            this.marcaDal = FactoryDal<MarcaDal>.GetDal();
            this.unidadMedidaBiz = new UnidadMedidaBiz();
        }

        public void Cargar()
        {
            this.productoDal.Cargar();
            this.materiaPrimaDal.Cargar();
            this.marcaDal.Cargar();
        }

        public int AgregarEditar(Producto producto)
        {
            return this.productoDal.AgregarEditar(producto);
        }

        public List<Producto> ObtenerLista()
        {
            var list = this.productoDal.ObtenerLista();
            list.ForEach(i =>
            {
                i.MateriaPrima = this.materiaPrimaDal.Obtener(i.IdMateriaPrima);
                i.Marca = this.marcaDal.Obtener(i.IdMarca);
                i.UnidadMedida = this.unidadMedidaBiz.ObtenerLista().FirstOrDefault(j => j.Codigo == i.CodigoUnidadMedida);
            });
            return list;
        }

        public void Eliminar(Producto producto)
        {
            this.productoDal.Eliminar(producto);
        }
    }
}
