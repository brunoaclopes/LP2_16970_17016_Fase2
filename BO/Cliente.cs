/*
*  -------------------------------------------------
* <copyright file=" Cliente " company="IPCA"/>
* <date> 5/6/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using System;

namespace BO
{
    /// <summary>
    /// Esta classe cliente descende de pessoa, dotando assim dos seus atributos e metodos. Alem do que se encontra na classe pessoa, cliente dispoem tambem de carros que é uma lista de carro que o cliente dispoem e da data em que esta pessoa começou a ser cliente da marca, tal como varios metodos para operar a referida lista e uma propriedade para operar com a data.
    /// </summary>
    [Serializable]
    public class Cliente : Pessoa, ICarros
    {
        #region Atributos
        private DateTime data;
        private Carros carros= new Carros();
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor com valores por defeito
        /// </summary>
        public Cliente() : base()
        {
            data = DateTime.Now;
        }

        /// <summary>
        /// Construtor com valores do exterior e data atual de inicio de atividade
        /// </summary>
        /// <param name="c">carro a introduzir em cliente</param>
        /// <param name="n">nome do cliente</param>
        /// <param name="nif">nif do cliente</param>
        /// <param name="dataNascimento">data de nascimento do cliente</param>
        public Cliente(string n, double nif, DateTime dataNascimento, Carro c) : base(n, nif, dataNascimento)
        {
            this.data = DateTime.Now;
            carros.AddCarro(c);
        }

        /// <summary>
        /// Construtor com valores do exterior
        /// </summary>
        /// <param name="data">data de quando a pessoa se tornou cliente</param>
        /// <param name="c">carro a introduzir em cliente</param>
        /// <param name="n">nome do cliente</param>
        /// <param name="nif">nif do cliente</param>
        /// <param name="dataNascimento">data de nascimento do cliente</param>
        public Cliente (string n, double nif, DateTime dataNascimento, DateTime data, Carro c) : base(n, nif, dataNascimento)
        {
            this.data = data;
            carros.AddCarro(c);
        }
        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade referente a data de inicio de atividade do Cliente.
        /// </summary>
        public DateTime Data
        {
            get { return data; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    data = value;
                }
            }
        }
        #endregion

        #region Metodos

        /// <summary>
        /// Metodo para adicionar um carro aos carros do clinete.
        /// </summary>
        /// <param name="c">carro a adicionar</param>
        public bool AddCarro (Carro c)
        {
            return carros.AddCarro(c);
        }

        /// <summary>
        /// Metodo para remover um carro dos carros do cliente.
        /// </summary>
        /// <param name="vin">vin do carro a remover</param>
        /// <returns></returns>
        public bool DeleteCarro (int vin)
        {
            return carros.DeleteCarro(vin);
        }

        /// <summary>
        /// Metodo para verificar se um carro com um determinado vin pertence a este cliente
        /// </summary>
        /// <param name="vin">vin a procurar</param>
        /// <returns></returns>
        public bool SearchCarro (int vin)
        {
            return (carros.SearchCarro(vin));
        }

        /// <summary>
        /// Metodo que procura e retorna se um carro existe ou nao na lista de carros do cliente com saida atravez de um parametro caso exista. 
        /// </summary>
        /// <param name="vin"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool SearchCarro(int vin, out Carro c)
        {
            return carros.SearchCarro(vin, out c);
        }

        /// <summary>
        /// Metodo que retorna os carros do cliente
        /// </summary>
        /// <returns></returns>
        public Carros GetCarros()
        {
            return carros;
        }

        /// <summary>
        /// Metodo que lista os carros de cliente
        /// </summary>
        public void ListCarros()
        {
            carros.ListCarros();
        }
        #endregion
    }
}