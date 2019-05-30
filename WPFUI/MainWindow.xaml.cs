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
