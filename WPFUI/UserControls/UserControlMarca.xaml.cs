/*
*  -------------------------------------------------
* <copyright file=" UserControlMarca " company="IPCA"/>
* <date> 5/27/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using BL;
using System.Windows.Controls;

namespace WPFUI
{
    /// <summary>
    /// Interaction logic for UserControlMarca.xaml
    /// </summary>
    public partial class UserControlMarca : UserControl
    {
        public UserControlMarca(BusinessLayer bl)
        {
            InitializeComponent();

            NConcessionarios.DataContext = bl.NConcessionarios();
            NCarros.DataContext = bl.NCarros();
            NComerciais.DataContext = bl.NComerciais();
            NClientes.DataContext = bl.NClientes();
        }
        
    }
}
