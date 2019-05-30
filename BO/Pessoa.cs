/*
*  -------------------------------------------------
* <copyright file=" Pessoa " company="IPCA"/>
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
    /// Esta classe dispoem de atributos correspondentes a carateristicas de uma pessoa, assim como propriedades e metodos para realizar as mais variadas operaçoes com os referidos atributos.
    /// </summary>
    [Serializable]
    public class Pessoa
    {
        #region Atributos
        private string nome;
        [NonSerialized]
        private int idade = 0;
        private DateTime dataNascimento = DateTime.MinValue;
        private double nif = 0;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor com valores por defeito.
        /// </summary>
        public Pessoa()
        {
            nome = "";
            dataNascimento = DateTime.MinValue;
            nif = 999999999;
            idade = CalculaIdade(dataNascimento);
        }
        
        /// <summary>
        /// Construtor com valor vindos do exterior
        /// </summary>
        /// <param name="nome">nome</param>
        /// <param name="nif">nif</param>
        /// <param name="data">data de nacimento</param>
        public Pessoa(string nome, double nif, DateTime data)
        {
            this.nome = nome;
            if (nif > 0 && nif < 1000000000) this.nif = nif;
            if (data < DateTime.Now) dataNascimento = data;
            idade = CalculaIdade(dataNascimento);
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para ver ou alterar o nome.
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Propriedade para ver ou alterar a data de nascimento (e por consequencia a idade).
        /// </summary>
        public DateTime DataNascimento
        {
            get { return dataNascimento; }
            set
            {
                DateTime aux;
                if (DateTime.TryParse(value.ToString(), out aux) == true)
                {
                    dataNascimento = value;
                }
                idade = CalculaIdade(dataNascimento);
            }
        }

        /// <summary>
        /// Propriedade que retorna a idade.
        /// </summary>
        public int Idade
        {
            get
            {
                idade = CalculaIdade(dataNascimento);
                return idade;
            }
            set
            {
                idade = value;
            }
        }

        /// <summary>
        /// Propriedade para ver ou alterar o NIF.
        /// </summary>
        public double Nif
        {
            get { return nif; }
            set
            {
                if (nif > 0 && nif < 1000000000) nif = value;
            }
        }
        #endregion

        #region OVERRIDES

        public override string ToString()
        {
            return string.Format("Nome= {0} - Idade= {1} - Nif= {2}", Nome, Idade, Nif);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que devolve a idade conforme uma data de nascimento.
        /// </summary>
        /// <param name="dN">Data de Nascimento</param>
        /// <returns></returns>
        public static int CalculaIdade(DateTime dN)
        {
            DateTime atual = DateTime.Now;
            int idade = atual.Year - dN.Year;

            if (atual.Month < dN.Month || (atual.Month == dN.Month && atual.Day < dN.Day))
                idade--;

            return idade;
        }
        #endregion
    }
}