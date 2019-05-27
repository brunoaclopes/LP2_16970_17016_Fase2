/*
*  -------------------------------------------------
* <copyright file=" DataLayer " company="IPCA"/>
* <date> 5/27/2019 10:53:03 AM </date>
* <author> bruno </author>
* <email> a16970@alunos.ipca.pt </email>
* <desc>
*   
* </desc>
* -------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DL
{
    /// <summary>
    /// Classe para operar os dados
    /// </summary>
    public class DataLayer
    {
        private string path = Path.GetFullPath(@"Data.json");
        private Marca marca;

        #region Construtor
        /// <summary>
        /// Construtor que verifica se existem dados a importar (caso nao existam cria uma marca vazia)
        /// </summary>
        public DataLayer()
        {
            try
            {
                Marca.ImportJson(out marca, path);
            }
            catch (FileNotFoundException e)
            {
                marca = new Marca();
            }
        }

        #endregion

        #region Contadores
        /// <summary>
        /// Conta o numero total de Concessionarios da marca
        /// </summary>
        /// <returns></returns>
        public int NConcessionarios()
        {
            return marca.Concessionarios.Count;
        }

        /// <summary>
        /// Conta o numero total de Carros em stock da marca
        /// </summary>
        /// <returns></returns>
        public int NCarros()
        {
            int n = 0;

            foreach(Concessionario c in marca.Concessionarios)
            {
                n += c.Carros.NCarros();
            }

            return n;
        }

        /// <summary>
        /// Conta o numero de carros de um determinado cliente
        /// </summary>
        /// <param name="nif">NIF do cliente</param>
        /// <returns></returns>
        public int NCarros(double nif)
        {
            return marca.Concessionarios.Find(var => var.SearchPessoa(nif) == true).GetCarros(nif).NCarros();
        }

        /// <summary>
        /// Conta o numero total de Comerciais da marca
        /// </summary>
        /// <returns></returns>
        public int NComerciais()
        {
            int n = 0;
            foreach (Concessionario c in marca.Concessionarios)
            {
                n += c.Pessoas.Comerciais.Count;
            }

            return n;
        }

        /// <summary>
        /// Conta o numero total de Clientes da marca
        /// </summary>
        /// <returns></returns>
        public int NClientes()
        {
            int n = 0;
            foreach (Concessionario c in marca.Concessionarios)
            {
                n += c.Pessoas.Clientes.Count;
            }

            return n;
        }
        #endregion

        public string NomeMarca()
        {
            return marca.Nome;
        }

        /// <summary>
        /// Metodo que exporta os dados para um ficheiro
        /// </summary>
        public void Export()
        {
            Marca.ExportJson(marca, path);
        }
    }

}
