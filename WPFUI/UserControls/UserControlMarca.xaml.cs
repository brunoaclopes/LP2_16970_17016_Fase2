using BL;
using System.Windows.Controls;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for UserControlMarca.xaml
    /// </summary>
    public partial class UserControlMarca : UserControl
    {
        public UserControlMarca(BusinessLayer bl)
        {
            InitializeComponent();

            NConcessionarios.DataContext = bl.NConcessionarios();
            NCarros.DataContext = bl.NCarros();
            NComerciais.DataContext = bl.NComerciais();
            NClientes.DataContext = bl.NClientes();
        }
        
    }
}
