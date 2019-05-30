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
using BO;

namespace WPFUI.UserControls
{
    /// <summary>
    /// Interaction logic for AddPessoa.xaml
    /// </summary>
    public partial class AddPessoa : Window
    {
        BusinessLayer bl;
        int id;
        Type type;
        
        public AddPessoa(BusinessLayer bl, int id, Type type)
        {
            this.bl = bl;
            this.id = id;
            this.type = type;
            InitializeComponent();
        }

        /// <summary>
        /// Metodo para adicionar a pessoa
        /// </summary>
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            

            if (double.TryParse(Nif.Text, out double nif) == false)
            {
                Nif.Text = "Valor não suportado";
            }
            else
            {
                if (type == typeof(Comercial))
                {
                    Comercial x = new Comercial(Nome.Text, nif, (DateTime)DataNascimento.SelectedDate, (DateTime)Data.SelectedDate);
                    bl.AddPessoa(id, (object)x);
                }
                else
                {
                    Cliente x = new Cliente(Nome.Text, nif, (DateTime)DataNascimento.SelectedDate, (DateTime)Data.SelectedDate);
                    bl.AddPessoa(id, (object)x);
                }
                
                this.Close();
            }

        }

        /// <summary>
        /// Metodo para fechar a janela
        /// </summary>
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
