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
using BL;

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for AddCarro.xaml
    /// </summary>
    public partial class AddCarro : Window
    {
        BusinessLayer bl;
        int id;

        public AddCarro(BusinessLayer bl, int id)
        {
            this.bl = bl;
            this.id = id;
            InitializeComponent();
        }

        /// <summary>
        /// Metodo para adicionar um carro ao clicar no botao
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            string modelo = Modelo.Text;
            DateTime data = (DateTime)Data.SelectedDate;
            if (int.TryParse(Vin.Text, out int vin) == false)
            {
                Vin.Text = "Valor não suportado";
            }
            else
            {
                bl.AddCarro(id, data, modelo, vin);
                this.Close();
            }

        }

        /// <summary>
        /// Metodo para fechar a janela
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
