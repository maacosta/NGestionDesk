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
        private Compra compra;
        private Compra compraPreliminar;

        public Compra Compra { get { return this.compra; } }

        public CompraDetalleLista()
        {
            this.proveedorBiz = new ProveedorBiz();
            this.compraPreliminar = new Compra() { Items = new List<CompraItem>() };

            InitializeComponent();
        }

        public void SetEntidad(Compra compra)
        {
            this.compraPreliminar = compra;

            this.dtpFechaCompra.SelectedDate = this.compraPreliminar.FechaCompra;
            this.txtPrecioTotal.Text = this.compraPreliminar.PrecioTotal.ToString();
            this.txtPrecioTotalConDescuento.Text = this.compraPreliminar.PrecioTotalConDescuento.ToString();
            this.cmbProveedor.SelectedItem = this.proveedorBiz.ObtenerLista().Find(i => i.Id == this.compraPreliminar.Proveedor.Id);

            this.CtlActualizarDtgLista();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
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
            var precioTotal = 0m;
            if (!decimal.TryParse(this.txtPrecioTotal.Text, out precioTotal))
            {
                MessageBox.Show("El precio total no tiene un formato valido");
                return;
            }
            var precioConDescuento = precioTotal;
            if (!string.IsNullOrEmpty(this.txtPrecioTotalConDescuento.Text) && !decimal.TryParse(this.txtPrecioTotalConDescuento.Text, out precioConDescuento))
            {
                MessageBox.Show("El precio total con descuento no tiene un formato valido");
                return;
            }

            this.compraPreliminar.FechaCompra = this.dtpFechaCompra.SelectedDate.Value;
            this.compraPreliminar.PrecioTotal = precioTotal;
            this.compraPreliminar.PrecioTotalConDescuento = precioConDescuento;
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

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
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

        private void txtPorcentajeDescuento_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal t, td = 0m;
            if(decimal.TryParse(this.txtPrecioTotal.Text, out t)&&decimal.TryParse(this.txtPrecioTotalConDescuento.Text, out td))
            {
                this.lblPorcentajeDescuento.Content = string.Format("{0:0.00} %", (td / t - 1m) * 100m);
            }
        }
    }
}
