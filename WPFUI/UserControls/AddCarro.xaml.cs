/*
*  -------------------------------------------------
* <copyright file=" AddCarro " company="IPCA"/>
* <date> 5/27/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using BL;
using System;
using System.Windows;

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
            DateTime data;
            if (Modelo.Text != "")
            {
                string modelo = Modelo.Text;
                if (Data.SelectedDate != null)
                {
                    data = (DateTime)Data.SelectedDate;
                }
                else
                {
                    data = DateTime.Now;
                }
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
