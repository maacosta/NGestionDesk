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
    public partial class CompraItemEntidad : Window
    {
        private ProductoBiz presentacionMateriaPrimaBiz;
        CompraItem compraItem;

        public CompraItem CompraItem { get { return this.compraItem; } }

        public CompraItemEntidad()
        {
            this.presentacionMateriaPrimaBiz = new ProductoBiz();

            InitializeComponent();
        }

        public void SetEntidad(CompraItem entidad)
        {
            this.compraItem = entidad;

            this.cmbPresentacionMateriaPrima.SelectedItem = this.presentacionMateriaPrimaBiz.ObtenerLista().FirstOrDefault(i => i.Id == this.compraItem.IdPresentacionMateriaPrima);
            this.txtCantidad.Text = this.compraItem.Cantidad.ToString();
            this.txtPrecioUnitario.Text = this.compraItem.PrecioUnitario.ToString();
            this.txtPrecioTotal.Text = this.compraItem.PrecioTotal.ToString();
            this.txtPrecioConDescuento.Text = this.compraItem.PrecioTotalConDescuento.ToString();
        }

        private void OnInitialized(object sender, EventArgs e)
        {
            this.presentacionMateriaPrimaBiz.Cargar();

            this.cmbPresentacionMateriaPrima.ItemsSource = this.presentacionMateriaPrimaBiz.ObtenerLista();
        }

        private void OnClickCancelar(object sender, RoutedEventArgs e)
        {
            this.compraItem = null;
            this.Close();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (this.cmbPresentacionMateriaPrima.SelectedItem == null)
            {
                MessageBox.Show("El producto es obligatorio");
                return;
            }
            var cantidad = 0;
            if (!int.TryParse(this.txtCantidad.Text, out cantidad))
            {
                MessageBox.Show("La cantidad no tiene un formato valido");
                return;
            }
            var precioUnitario = 0m;
            if (!string.IsNullOrEmpty(this.txtPrecioUnitario.Text) && !decimal.TryParse(this.txtPrecioUnitario.Text, out precioUnitario))
            {
                MessageBox.Show("El precio unitario no tiene un formato valido");
                return;
            }
            var precioTotal = 0m;
            if (!string.IsNullOrEmpty(this.txtPrecioTotal.Text) && !decimal.TryParse(this.txtPrecioTotal.Text, out precioTotal))
            {
                MessageBox.Show("El precio total no tiene un formato valido");
                return;
            }
            var precioConDescuento = 0m;
            if (!string.IsNullOrEmpty(this.txtPrecioConDescuento.Text) && !decimal.TryParse(this.txtPrecioConDescuento.Text, out precioConDescuento))
            {
                MessageBox.Show("El precio con descuento no tiene un formato valido");
                return;
            }
            if(precioUnitario > 0m && precioTotal > 0m)
            {
                MessageBox.Show("Solo debe completar el precio unitario o precio total");
                return;
            }

            if (precioUnitario > 0m) precioTotal = cantidad * precioUnitario;
            if (precioTotal > 0m) precioUnitario = precioTotal / cantidad;
            
            if(precioConDescuento > precioTotal)
            {
                MessageBox.Show("El precio con descuento no puede ser mayor al precio total");
                return;
            }

            if (precioConDescuento == 0m) precioConDescuento = precioTotal;

            this.compraItem = new CompraItem();
            this.compraItem.PresentacionMateriaPrima = (Producto)this.cmbPresentacionMateriaPrima.SelectedItem;
            if (this.compraItem.PresentacionMateriaPrima != null) this.compraItem.IdPresentacionMateriaPrima = this.compraItem.PresentacionMateriaPrima.Id;
            this.compraItem.Cantidad = cantidad;
            this.compraItem.PrecioUnitario = precioUnitario;
            this.compraItem.PrecioTotal = precioTotal;
            this.compraItem.PrecioTotalConDescuento = precioConDescuento;

            this.Close();
        }
    }
}
