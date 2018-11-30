using log4net;
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
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public Principal()
        {
            InitializeComponent();
        }

        private void OnClickMateriaPrima(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                var mp = new MateriaPrimaList();
                //mp.WindowState = System.Windows.WindowState.Maximized;
                mp.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                log.Error("MateriaPrima", ex);
            }
        }

        private void OnClickCompra(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Hide();
                var c = new CompraLista();
                //c.WindowState = System.Windows.WindowState.Maximized;
                c.ShowDialog();
                this.Show();
            }
            catch (Exception ex)
            {
                log.Error("Compra", ex);
            }
        }
    }
}
