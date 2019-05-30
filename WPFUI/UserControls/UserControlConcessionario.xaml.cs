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

        /// <summary>
        /// Metodo para permitir controlar a lista com a roda do rato
        /// </summary>
        private void ListaConcessionarios_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        /// <summary>
        /// Metodo para carregar os dados na lista
        /// </summary>
        private void LoadDataTemplate()
        {
            ListaConcessionarios.ItemsSource = bl.Concessionarios();
        }

        /// <summary>
        /// Metodo para adicionar um concessionario ao clicar no botao
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            bl.AddConcessionario();
            ListaConcessionarios.Items.Refresh();
        }

        /// <summary>
        /// Metodo para remover um concessionario ao clicar no botao
        /// </summary>
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
