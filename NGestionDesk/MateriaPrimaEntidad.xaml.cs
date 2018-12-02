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
    public partial class MateriaPrimaEntidad : Window
    {
        private MateriaPrimaBiz materiaPrimaBiz;
        private UnidadBiz unidadBiz;

        private MateriaPrima entidad;

        public MateriaPrimaEntidad()
        {
            this.materiaPrimaBiz = new MateriaPrimaBiz();
            this.unidadBiz = new UnidadBiz();

            InitializeComponent();
        }

        public void SetEntidad(MateriaPrima entidad)
        {
            this.entidad = entidad;

            this.txtDescripcion.Text = this.entidad.Descripcion;
            this.cmbUnidad.SelectedItem = this.unidadBiz.ObtenerLista().Find(i => i.Codigo == this.entidad.CodigoUnidad);
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            this.materiaPrimaBiz.Cargar();

            this.cmbUnidad.ItemsSource = this.unidadBiz.ObtenerLista();
        }

        private void OnClickCancelar(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (this.entidad == null)
            {
                this.entidad = new MateriaPrima();
            }

            this.entidad.Descripcion = this.txtDescripcion.Text;
            this.entidad.Unidad = (Unidad)this.cmbUnidad.SelectedItem;
            this.entidad.CodigoUnidad = this.entidad.Unidad.Codigo;

            this.materiaPrimaBiz.Agregar(this.entidad);

            this.Close();
        }
    }
}
