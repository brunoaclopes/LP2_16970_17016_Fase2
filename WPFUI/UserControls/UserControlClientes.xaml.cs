﻿/*
*  -------------------------------------------------
* <copyright file=" UserControlClientes " company="IPCA"/>
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
    /// Interaction logic for UserControlClientes.xaml
    /// </summary>
    public partial class UserControlClientes : UserControl
    {
        BusinessLayer bl;

        public UserControlClientes(BusinessLayer bl)
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
        private void ListaClientes_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
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

            ListaClientes.ItemsSource = bl.ListaClientes(id);
            ListaClientes.Items.Refresh();
        }

        /// <summary>
        /// Metodo para abrir a janela de inscriçao de uma nova pessoa
        /// </summary>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (IDComboBox.SelectedItem != null)
            {
                UserControls.AddPessoa ficha = new UserControls.AddPessoa(bl, ((Concessionario)IDComboBox.SelectedItem).Id, typeof(Cliente));
                ListaClientes.Items.Refresh();
                ficha.Show();
            }
        }

        /// <summary>
        /// Metodo para remover item selecionado na lista
        /// </summary>
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ListaClientes.SelectedItem != null && IDComboBox.SelectedItem != null)
            {
                bl.DeletePessoa(((Pessoa)ListaClientes.SelectedItem).Nif);
            }
            ListaClientes.Items.Refresh();
        }

        private void AdministrarCarros_Click(object sender, RoutedEventArgs e)
        {
            if (ListaClientes.SelectedItem != null && IDComboBox.SelectedItem != null)
            {
                UserControls.AddCarroCliente win = new UserControls.AddCarroCliente(bl, ((Pessoa)ListaClientes.SelectedItem).Nif);
                win.Show();
            }
        }
    }
}
