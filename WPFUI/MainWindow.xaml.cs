/*
*  -------------------------------------------------
* <copyright file=" MainWindow " company="IPCA"/>
* <date> 5/27/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using BL;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BusinessLayer bl;

        public MainWindow()
        {
            bl = new BusinessLayer();
            InitializeComponent();
            Marca.DataContext = bl.NomeMarca();
        }

        /// <summary>
        /// Metodo para permitir mover a janela ao arrastar a barra superior
        /// </summary>
        private void GridBarraTitulo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        /// <summary>
        /// Metodo para fechar o programa e guardar os dados
        /// </summary>
        private void ButtonFechar_Click(object sender, RoutedEventArgs e)
        {
            bl.Export();
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Metodo para fazer variar a grid principal conforme a opçao no menu
        /// </summary>
        private void MenuListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = MenuListView.SelectedIndex;

            switch (index)
            {
                case 0:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlMarca(bl));
                    break;
                case 1:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlConcessionario(bl));
                    break;
                case 2:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlCarros(bl));
                    break;
                case 3:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlComerciais(bl));
                    break;
                case 4:
                    GridPrincipal.Children.Clear();
                    GridPrincipal.Children.Add(new UserControlClientes(bl));
                    break;
                default:
                    break;
            }

        }
    }
}
