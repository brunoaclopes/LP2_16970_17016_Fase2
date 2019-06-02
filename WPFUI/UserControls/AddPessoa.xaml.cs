/*
*  -------------------------------------------------
* <copyright file=" AddPessoa " company="IPCA"/>
* <date> 5/27/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using BL;
using BO;
using System;
using System.Windows;

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
            if (Nome.Text != "" && DataNascimento.SelectedDate != null && Data.SelectedDate != null)
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
