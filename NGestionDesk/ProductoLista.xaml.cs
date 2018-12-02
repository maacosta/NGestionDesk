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
    public partial class ProductoList : Window
    {
        private ProductoBiz productoBiz;

        public ProductoList()
        {
            this.productoBiz = new ProductoBiz();

            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            this.productoBiz.Cargar();

            this.CtlActualizarDtgLista();
        }

        private void CtlActualizarDtgLista()
        {
            var list = this.productoBiz.ObtenerLista();

            this.dtgLista.ItemsSource = null;
            this.dtgLista.ItemsSource = list;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            var nuevo = new ProductoEntidad();
            nuevo.ShowDialog();

            this.CtlActualizarDtgLista();
        }

        private void dtgLista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.dtgLista.SelectedItem == null) return;

            var mp = (Producto)this.dtgLista.SelectedItem;
            var edicion = new ProductoEntidad();
            edicion.SetEntidad(mp);
            edicion.ShowDialog();

            this.CtlActualizarDtgLista();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtgLista.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un item para borrarlo");
                return;
            }

            var mp = (Producto)this.dtgLista.SelectedItem;
            this.productoBiz.Eliminar(mp);

            this.CtlActualizarDtgLista();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
