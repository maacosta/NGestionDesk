using NGestionDesk.Business;
using NGestionDesk.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NGestionDesk
{
    /// <summary>
    /// Interaction logic for MateriaPrimaEntidad.xaml
    /// </summary>
    public partial class ProductoEntidad : Window
    {
        private ProductoBiz productoBiz;
        private MateriaPrimaBiz materiaPrimaBiz;
        private UnidadMedidaBiz unidadMedidaBiz;
        private MarcaBiz marcaBiz;

        private List<UnidadMedida> unidadMedidaList;

        private Producto entidad;

        public ProductoEntidad()
        {
            this.productoBiz = new ProductoBiz();
            this.materiaPrimaBiz = new MateriaPrimaBiz();
            this.unidadMedidaBiz = new UnidadMedidaBiz();
            this.marcaBiz = new MarcaBiz();

            InitializeComponent();
        }

        public void SetEntidad(Producto entidad)
        {
            this.entidad = entidad;

            this.txtDescripcion.Text = this.entidad.Descripcion;
            this.cmbMateriaPrima.SelectedItem = this.materiaPrimaBiz.ObtenerLista().FirstOrDefault(i => i.Id == this.entidad.IdMateriaPrima);
            this.cmbUnidadMedida.SelectedItem = this.unidadMedidaList.FirstOrDefault(i => i.Codigo == this.entidad.CodigoUnidadMedida);
            this.txtCantidad.Text = this.entidad.Cantidad.ToString();
            this.cmbMarca.SelectedItem = this.marcaBiz.ObtenerLista().FirstOrDefault(i => i.Id == this.entidad.IdMarca);
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            this.productoBiz.Cargar();
            this.materiaPrimaBiz.Cargar();
            this.marcaBiz.Cargar();

            this.unidadMedidaList = this.unidadMedidaBiz.ObtenerLista();
            this.cmbMateriaPrima.ItemsSource = this.materiaPrimaBiz.ObtenerLista();
            this.cmbMarca.ItemsSource = this.marcaBiz.ObtenerLista();
        }

        private void OnClickCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmbMateriaPrima.SelectedItem == null)
            {
                MessageBox.Show("La materia prima es obligatoria");
                return;
            }
            if (this.cmbUnidadMedida.SelectedItem == null)
            {
                MessageBox.Show("La unidad de medida es obligatoria");
                return;
            }
            var cantidad = 0;
            if (!int.TryParse(this.txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("La cantidad no tiene un formato valido");
                return;
            }

            if (this.entidad == null)
            {
                this.entidad = new Producto();
            }

            this.entidad.Descripcion = this.txtDescripcion.Text;
            this.entidad.MateriaPrima = (MateriaPrima)this.cmbMateriaPrima.SelectedItem;
            if(this.entidad.MateriaPrima != null) this.entidad.IdMateriaPrima = this.entidad.MateriaPrima.Id;
            this.entidad.UnidadMedida = (UnidadMedida)this.cmbUnidadMedida.SelectedItem;
            if(this.entidad.UnidadMedida != null) this.entidad.CodigoUnidadMedida = this.entidad.UnidadMedida.Codigo;
            this.entidad.Cantidad = cantidad;
            this.entidad.Marca = (Marca)this.cmbMarca.SelectedItem;
            if (this.entidad.Marca != null) this.entidad.IdMarca = this.entidad.Marca.Id;

            this.productoBiz.AgregarEditar(this.entidad);

            this.Close();
        }

        private void cmbMateriaPrima_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var mp = (MateriaPrima)this.cmbMateriaPrima.SelectedItem;
            this.cmbUnidadMedida.ItemsSource = this.unidadMedidaList.Where(i => i.CodigoUnidad == mp.CodigoUnidad);
        }
    }
}
