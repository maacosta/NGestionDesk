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
    public partial class MateriaPrimaList : Window
    {
        private MateriaPrimaBiz materiaPrimaBiz;

        public MateriaPrimaList()
        {
            this.materiaPrimaBiz = new MateriaPrimaBiz();

            InitializeComponent();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            this.materiaPrimaBiz.Cargar();

            this.CtlActualizarDtgLista();
        }

        private void CtlActualizarDtgLista()
        {
            var list = this.materiaPrimaBiz.ObtenerLista();

            this.dtgLista.ItemsSource = null;
            this.dtgLista.ItemsSource = list;
        }

        private void OnClick(object sender, RoutedEventArgs e)
        {
            var nuevo = new MateriaPrimaEntidad();
            nuevo.ShowDialog();

            this.CtlActualizarDtgLista();
        }

        private void dtgLista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.dtgLista.SelectedItem == null) return;

            var mp = (MateriaPrima)this.dtgLista.SelectedItem;
            var edicion = new MateriaPrimaEntidad();
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

            var mp = (MateriaPrima)this.dtgLista.SelectedItem;
            this.materiaPrimaBiz.Eliminar(mp);

            this.CtlActualizarDtgLista();
        }
    }
}
