/*
*  -------------------------------------------------
* <copyright file=" Carros " company="IPCA"/>
* <date> 5/6/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using System;
using System.Collections.Generic;

namespace BO
{
    /// <summary>
    /// Nesta classe temos uma lista de carro e os metodos para manipular e interagir com essa lista.
    /// </summary>
    [Serializable]
    public class Carros
    {
        #region Atributos
        private List<Carro> c = new List<Carro>();
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Carros() { }

        /// <summary>
        /// Construtor com lista iniciada por um objeto fornecido.
        /// </summary>
        /// <param name="c">objeto a inserir</param>
        public Carros(Carro c)
        {
            AddCarro(c);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo para adicionar um carro a lista.
        /// </summary>
        /// <param name="c">objeto tipo Carro a adicionar</param>
        public bool AddCarro(Carro c)
        {
            if (!this.c.Exists(var => var.Vin == c.Vin))
            {
                this.c.Add(c);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo para apagar um carro da lista.
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        public bool DeleteCarro(int vin)
        {
            if (c.Exists(var => var.Vin == vin))
            {
                c.Remove(c.Find(var => var.Vin == vin));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que procura e retorna se um carro existe ou nao na lista com saida atravez de um parametro caso exista. 
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <param name="c">Parametro de saido do objeto carro caso seja encontrado</param>
        /// <returns></returns>
        public bool SearchCarro(int vin, out Carro c)
        {
            c = null;
            if (this.c.Exists(var => var.Vin == vin))
            {
                c = this.c.Find(var => var.Vin == vin);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que procura e retorna se um carro existe ou nao no array. 
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        public bool SearchCarro(int vin)
        {
            return (c.Exists(var => var.Vin == vin));
        }

        /// <summary>
        /// Metodo para listar tds os carros de uma lista.
        /// </summary>
        public void ListCarros()
        {
            Console.WriteLine();
            foreach (Carro var in c)
            {
                Console.WriteLine(var.ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Metodo que retorna o numero de carros da lista
        /// </summary>
        /// <returns></returns>
        public int NCarros()
        {
            return c.Count;
        }
        #endregion
    }
}