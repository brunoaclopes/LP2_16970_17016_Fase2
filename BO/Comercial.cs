/*
*  -------------------------------------------------
* <copyright file=" Comercial " company="IPCA"/>
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
    /// Esta classe comercial descende da classe pessoa, dotando assim dos seus metodos e atributos, mas alem desses, Comercial dispoe de um atributo data que corresponde a data em que esta pessoa começou atrabalhar como comercial da marca, assim como de uma propriedade para operar com essa mesma data.
    /// </summary>
    [Serializable]
    public class Comercial : Pessoa
    {
        #region Atributos
        private DateTime data;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor com valores por defeito
        /// </summary>
        public Comercial() : base()
        {
            data = DateTime.Now;
        }

        /// <summary>
        /// Construtor com valores do exterior e data atual de inicio de atividade
        /// </summary>
        /// <param name="n">nome do comercial</param>
        /// <param name="nif">nif do comercial</param>
        /// <param name="dataNascimento">data de nascimento do comercial</param>
        public Comercial(string n, double nif, DateTime dataNascimento) : base(n, nif, dataNascimento)
        {
            this.data = DateTime.Now;
        }

        /// <summary>
        /// Construtor com valores do exterior
        /// </summary>
        /// <param name="data">data de quando a pessoa se tornou comercial</param>
        /// <param name="n">nome do comercial</param>
        /// <param name="nif">nif do comercial</param>
        /// <param name="dataNascimento">data de nascimento do comercial</param>
        public Comercial(string n, double nif, DateTime dataNascimento, DateTime data) : base(n, nif, dataNascimento)
        {
            this.data = data;
        }
        #endregion

        #region Propriedades

        /// <summary>
        /// Propriedade referente a data de inicio de atividade do Comercial.
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

        /// <summary>
        /// Propriedade para fornecer a data formatada
        /// </summary>
        public string StringData
        {
            get { return data.ToString("d"); }
        }
        #endregion
    }
}