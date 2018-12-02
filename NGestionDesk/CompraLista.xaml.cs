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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NGestionDesk
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CompraLista : Window
    {
        private DateTime fechaSeleccion;
        private CompraBiz compraBiz;

        public CompraLista()
        {
            this.fechaSeleccion = DateTime.Now;
            this.compraBiz = new CompraBiz(this.fechaSeleccion);

            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            this.compraBiz.Cargar();

            this.txtAnio.Text = this.fechaSeleccion.Year.ToString();

            var mesList = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(1, "Enero"),
                new KeyValuePair<int, string>(2, "Febrero"),
                new KeyValuePair<int, string>(3, "Marzo"),
                new KeyValuePair<int, string>(4, "Abril"),
                new KeyValuePair<int, string>(5, "Mayo"),
                new KeyValuePair<int, string>(6, "Junio"),
                new KeyValuePair<int, string>(7, "Julio"),
                new KeyValuePair<int, string>(8, "Agosto"),
                new KeyValuePair<int, string>(9, "Septiembre"),
                new KeyValuePair<int, string>(10, "Octubre"),
                new KeyValuePair<int, string>(11, "Noviembre"),
                new KeyValuePair<int, string>(12, "Diciembre"),
            };

            this.cmbMes.DisplayMemberPath = "Key";
            this.cmbMes.SelectedValuePath = "Value";
            this.cmbMes.ItemsSource = mesList;
            this.cmbMes.SelectedItem = mesList.Find(i => i.Key == this.fechaSeleccion.Month);

            this.CtlActualizarDtgLista();
        }

        private void CtlActualizarDtgLista()
        {
            var list = this.compraBiz.ObtenerLista();

            this.dtgLista.ItemsSource = null;
            this.dtgLista.ItemsSource = list;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var nuevo = new CompraDetalleLista();
            nuevo.ShowDialog();

            if (nuevo.Compra != null)
            {
                this.compraBiz.AgregarEditar(nuevo.Compra);
                this.CtlActualizarDtgLista();
            }
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtgLista.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un item para borrarlo");
                return;
            }

            var c = (Compra)this.dtgLista.SelectedItem;
            this.compraBiz.Eliminar(c);

            this.CtlActualizarDtgLista();
        }

        private void dtgLista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.dtgLista.SelectedItem == null) return;

            var c = (Compra)this.dtgLista.SelectedItem;
            var edicion = new CompraDetalleLista();
            edicion.SetEntidad(c);
            edicion.ShowDialog();

            if (edicion.Compra != null)
            {
                this.compraBiz.AgregarEditar(edicion.Compra);
                this.CtlActualizarDtgLista();
            }
        }

        private void cmbMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.CargarDatosCompraList();
        }

        private void txtAnio_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.CargarDatosCompraList();
        }

        private void CargarDatosCompraList()
        {
            if (this.cmbMes.SelectedItem == null) return;

            var anio = 0;
            if(!int.TryParse(this.txtAnio.Text, out anio) && anio < 2000 && anio > 3000)
            {
                MessageBox.Show("El año no tiene un formato valido");
                this.txtAnio.Text = this.fechaSeleccion.Year.ToString();
                return;
            }
            var ms = (KeyValuePair<int, string>)this.cmbMes.SelectedItem;

            this.fechaSeleccion = new DateTime(anio, ms.Key, 1);
            this.compraBiz = new CompraBiz(this.fechaSeleccion);

            this.compraBiz.Cargar();

            this.CtlActualizarDtgLista();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
