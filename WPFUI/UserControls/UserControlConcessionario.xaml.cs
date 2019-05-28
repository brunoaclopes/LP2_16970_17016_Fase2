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
using BL;
using BO;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for UserControlConcessionario.xaml
    /// </summary>
    public partial class UserControlConcessionario : UserControl
    {
        BusinessLayer bl;

        public UserControlConcessionario(BusinessLayer bl)
        {
            InitializeComponent();
            this.bl = bl;
            LoadDataTemplate();
        }

        private void ListaConcessionarios_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void LoadDataTemplate()
        {
            ListaConcessionarios.ItemsSource = bl.Concessionarios();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bl.AddConcessionario();
            ListaConcessionarios.Items.Refresh();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            int id;
            if (ListaConcessionarios.SelectedItem != null)
            {
                id = ((Concessionario)ListaConcessionarios.SelectedItem).Id;

                bl.DeleteConcessionario(id);
                
                ListaConcessionarios.Items.Refresh();
            }
        }
    }
}
