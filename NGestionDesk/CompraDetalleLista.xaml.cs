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
    public partial class CompraDetalleLista : Window
    {
        private ProveedorBiz proveedorBiz;
        private ProductoBiz presentacionMateriaPrimaBiz;

        private Compra compra;
        private Compra compraPreliminar;

        public Compra Compra { get { return this.compra; } }

        public CompraDetalleLista()
        {
            this.presentacionMateriaPrimaBiz = new ProductoBiz();
            this.proveedorBiz = new ProveedorBiz();

            this.compraPreliminar = new Compra() { Items = new List<CompraItem>() };

            InitializeComponent();
        }

        public void SetEntidad(Compra compra)
        {
            this.compraPreliminar = compra;

            if (this.compraPreliminar.Items != null) 
                this.compraPreliminar.Items
                    .ForEach(i => i.PresentacionMateriaPrima = this.presentacionMateriaPrimaBiz.ObtenerLista().FirstOrDefault(j => j.Id == i.IdPresentacionMateriaPrima));

            this.dtpFechaCompra.SelectedDate = this.compraPreliminar.FechaCompra;
            this.cmbProveedor.SelectedItem = this.proveedorBiz.ObtenerLista().FirstOrDefault(i => i.Id == this.compraPreliminar.IdProveedor);

            this.CtlActualizarDtgLista();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            this.presentacionMateriaPrimaBiz.Cargar();
            this.proveedorBiz.Cargar();

            this.dtpFechaCompra.SelectedDate = DateTime.Now;
            this.CtlActualizarProveedores();
            this.CtlActualizarDtgLista();
        }

        private void CtlActualizarProveedores()
        {
            this.cmbProveedor.ItemsSource = this.proveedorBiz.ObtenerLista();
        }
        private void CtlActualizarDtgLista()
        {
            var t = this.compraPreliminar.Items.Sum(i => i.PrecioTotal);
            var td = this.compraPreliminar.Items.Sum(i => i.PrecioTotalConDescuento);

            this.lblPrecioTotalCalculado.Content = t.ToString();
            this.lblPrecioTotalCalculadoConDescuento.Content = td.ToString();
            this.lblPorcentajeDescuento.Content = t != 0m && td != t ? string.Format("{0:0.00} %", (td / t - 1m) * 100m) : string.Empty;

            this.dtgLista.ItemsSource = null;
            this.dtgLista.ItemsSource = this.compraPreliminar.Items;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //completar el objeto Compra
            if (!this.dtpFechaCompra.SelectedDate.HasValue)
            {
                MessageBox.Show("Debe seleccionar una fecha de compra");
                return;
            }

            this.compraPreliminar.FechaCompra = this.dtpFechaCompra.SelectedDate.Value;
            this.compraPreliminar.Proveedor = (Proveedor)this.cmbProveedor.SelectedItem;

            this.compra = this.compraPreliminar;

            this.Close();
        }

        private void btnAgregarItem_Click(object sender, RoutedEventArgs e)
        {
            var nuevo = new CompraItemEntidad();
            nuevo.ShowDialog();

            if (nuevo.CompraItem != null)
            {
                this.compraPreliminar.Items.Add(nuevo.CompraItem);
                this.CtlActualizarDtgLista();
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.compra = null;
            this.Close();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            if (this.dtgLista.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un item para borrarlo");
                return;
            }

            var ci = (CompraItem)this.dtgLista.SelectedItem;

            this.compraPreliminar.Items.Remove(ci);

            this.CtlActualizarDtgLista();
        }

        private void dtgLista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.dtgLista.SelectedItem == null) return;

            var ci = (CompraItem)this.dtgLista.SelectedItem;
            var edicion = new CompraItemEntidad();
            edicion.SetEntidad(ci);
            edicion.ShowDialog();

            if (edicion.CompraItem != null)
            {
                var index = this.compraPreliminar.Items.IndexOf(ci);
                this.compraPreliminar.Items.RemoveAt(index);
                this.compraPreliminar.Items.Insert(index, edicion.CompraItem);

                this.CtlActualizarDtgLista();
            }
        }
    }
}
