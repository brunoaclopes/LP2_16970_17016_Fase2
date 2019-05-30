/*
*  -------------------------------------------------
* <copyright file=" AddCarroCliente " company="IPCA"/>
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

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for AddCarroCliente.xaml
    /// </summary>
    public partial class AddCarroCliente : Window
    {
        BusinessLayer bl;
        double nif;
        public AddCarroCliente(BusinessLayer bl, double nif)
        {
            this.bl = bl;
            this.nif = nif;
            InitializeComponent();
            LoadListas();
        }

        /// <summary>
        /// Metodo que carrega os dados nas listas
        /// </summary>
        private void LoadListas()
        {
            ListaCarros.ItemsSource = bl.Carros();
            ListaCarrosCliente.ItemsSource = bl.ListaCarros(nif);
            ListaCarros.Items.Refresh();
            ListaCarrosCliente.Items.Refresh();
        }

        /// <summary>
        /// Metodo para permitir controlar a lista com a roda do rato
        /// </summary>
        private void ListaCarros_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        /// <summary>
        /// Metodo para permitir controlar a lista com a roda do rato
        /// </summary>
        private void ListaCarrosCliente_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        /// <summary>
        /// Metodo para fechar a janela
        /// </summary>
        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Cliente adquire um carro do concessionario no clique do botao
        /// </summary>
        private void Adquirir_Click(object sender, RoutedEventArgs e)
        {
            if(ListaCarros.SelectedItem != null)
            {
                bl.AdquirirCarro(nif, ((Carro)ListaCarros.SelectedItem));
            }
            LoadListas();
        }

        /// <summary>
        /// Remove um carro do cliente ao carregar no botao
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Remover_Click(object sender, RoutedEventArgs e)
        {
            if (ListaCarrosCliente.SelectedItem != null)
            {
                bl.DeleteCarroCliente(((Carro)ListaCarrosCliente.SelectedItem).Vin);
            }
            LoadListas();
        }
    }
}
