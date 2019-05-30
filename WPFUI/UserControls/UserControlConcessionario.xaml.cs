/*
*  -------------------------------------------------
* <copyright file=" UserControlConcessionario " company="IPCA"/>
* <date> 5/27/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using BL;
using BO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
