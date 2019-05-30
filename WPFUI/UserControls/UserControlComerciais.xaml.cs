/*
*  -------------------------------------------------
* <copyright file=" UserControlComerciais " company="IPCA"/>
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
    /// Interaction logic for UserControlComerciais.xaml
    /// </summary>
    public partial class UserControlComerciais : UserControl
    {
        BusinessLayer bl;

        public UserControlComerciais(BusinessLayer bl)
        {
            this.bl = bl;
            InitializeComponent();
            LoadComboBoxData();
        }


        /// <summary>
        /// Carrega os dados da ComboBox
        /// </summary>
        private void LoadComboBoxData()
        {
            IDComboBox.ItemsSource = bl.Concessionarios();
        }
        
        /// <summary>
        /// Metodo para permitir controlar a lista com a roda do rato
        /// </summary>
        private void ListaComerciais_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        /// <summary>
        /// Metodo para carregar os dados na lista conforme a opçao escolhida na ComboBox
        /// </summary>
        private void IDComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int id = ((Concessionario)IDComboBox.SelectedItem).Id;

            ListaComerciais.ItemsSource = bl.ListaComerciais(id);
            ListaComerciais.Items.Refresh();
        }

        /// <summary>
        /// Metodo para abrir a janela de inscriçao de uma nova pessoa
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (IDComboBox.SelectedItem != null)
            {
                UserControls.AddPessoa ficha = new UserControls.AddPessoa(bl, ((Concessionario)IDComboBox.SelectedItem).Id, typeof(Comercial));
                ListaComerciais.Items.Refresh();
                ficha.Show();
            }
        }

        /// <summary>
        /// Metodo para remover item selecionado na lista
        /// </summary>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListaComerciais.SelectedItem != null && IDComboBox.SelectedItem != null)
            {
                bl.DeletePessoa(((Pessoa)ListaComerciais.SelectedItem).Nif);
            }
            ListaComerciais.Items.Refresh();
        }
    }
}
