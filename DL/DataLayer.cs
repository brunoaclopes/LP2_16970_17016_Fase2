/*
*  -------------------------------------------------
* <copyright file=" DataLayer " company="IPCA"/>
* <date> 5/27/2019 10:53:03 AM </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
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

        /// <summary>
        /// Metodo que fornece o nome da marca
        /// </summary>
        public string NomeMarca()
        {
            return marca.Nome;
        }

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
                if (c.Carros != null) n += c.Carros.NCarros();
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
                if (c.Pessoas != null) n += c.Pessoas.Comerciais.Count;
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
                if (c.Pessoas != null) n += c.Pessoas.Clientes.Count;
            }

            return n;
        }
        #endregion

        #region Metodos Concessionarios
        /// <summary>
        /// Metodo que fornece uma lista com os concessionarios da marca
        /// </summary>
        /// <returns></returns>
        public List<Concessionario> Concessionarios()
        {
            return marca.Concessionarios;
        }

        /// <summary>
        /// Metodo para adicionar um concessionario
        /// </summary>
        /// <param name="id">id a adicionar</param>
        public void AddConcessionario(int id)
        {
            marca.AddConc(new Concessionario(id));
        }

        /// <summary>
        /// Metodo para remover um concessionario
        /// </summary>
        /// <param name="id">id a remover</param>
        public void DeleteConcessionario(int id)
        {
            marca.DeleteConc(id);
        }
        #endregion

        #region Metodos Carros
        /// <summary>
        /// Metodo que fornece uma lista com todos os carros da marca
        /// </summary>
        /// <returns></returns>
        public List<Carro> Carros()
        {
            List<Carro> carros = new List<Carro>();

            foreach (Concessionario c in marca.Concessionarios)
            {
                try
                {
                    carros.AddRange(c.Carros.LCarros);
                }
                catch (NullReferenceException e)
                {
                    continue;
                }
            }

            return carros;
        }

        /// <summary>
        /// Metodo que retorna um objeto carros que contem os varios carros de um concessionario
        /// </summary>
        /// <param name="id">id do concessionario</param>
        /// <returns></returns>
        public Carros Carros(int id)
        {
            return marca.Concessionarios.Find(var => var.Id == id).Carros;
        }

        /// <summary>
        /// Metodo que retorna um objeto carros que contem os varios carros de um cliente
        /// </summary>
        /// <param name="nif">nif do cliente</param>
        /// <returns></returns>
        public Carros Carros(double nif)
        {
            return marca.Concessionarios.Find(var => var.Pessoas.SearchPessoa(nif) == true).GetCarros(nif);
        }

        /// <summary>
        /// Metodo para adicionar um carro a um concessionario
        /// </summary>
        /// <param name="id">id do concessionario</param>
        /// <param name="c">carro a adicionar</param>
        public void AddCarro(int id, Carro c)
        {
            if (!marca.Concessionarios.Exists(var => var.SearchCarro(c.Vin) == true)) marca.Concessionarios.Find(var => var.Id == id).AddCarro(c);
        }

        /// <summary>
        /// Metodo para adicionar um carro a um cliente
        /// </summary>
        /// <param name="nif">nif do cliente</param>
        /// <param name="c">carro a adicionar</param>
        public void AddCarro(double nif, Carro c)
        {
            marca.Concessionarios.Find(var => var.SearchPessoa(nif) == true).AddCarro(nif, c);
        }

        /// <summary>
        /// Metodo para remover um carro de um concessionario
        /// </summary>
        /// <param name="vin">vin do carro a remover</param>
        public void DeleteCarroConcessionario(int vin)
        {
            if (marca.Concessionarios.Find(var => var.SearchCarro(vin) == true) != null) marca.Concessionarios.Find(var => var.SearchCarro(vin) == true).DeleteCarro(vin);
        }

        /// <summary>
        /// Metodo para remover um carro de um cliente
        /// </summary>
        /// <param name="vin">vin do carro a remover</param>
        public void DeleteCarroCliente(int vin)
        {
            marca.Concessionarios.Find(var => var.Pessoas.Clientes.Find(var2 => var2.SearchCarro(vin) == true).SearchCarro(vin) == true).DeleteCarroClintes(vin);
        }
        #endregion

        #region Metodos Pessoas
        /// <summary>
        /// Metodo que retorna um objeto pessoas que contem varios clientes e comerciais de um concessionario
        /// </summary>
        /// <param name="id">id do concessionario</param>
        /// <returns></returns>
        public Pessoas Pessoas(int id)
        {
            return marca.Concessionarios.Find(var => var.Id == id).Pessoas;
        }

        /// <summary>
        /// Metodo para adicionar uma pessoa a um concessionario
        /// </summary>
        /// <param name="id">id do concessionario</param>
        /// <param name="o">pessoa a adicionar</param>
        public void AddPessoa(int id, object o)
        {
            if (!marca.Concessionarios.Exists(var => var.SearchPessoa(((Pessoa)o).Nif) == true)) marca.Concessionarios.Find(var => var.Id == id).AddPessoa(o);
        }

        /// <summary>
        /// Metodo para remover uma pessoa
        /// </summary>
        /// <param name="nif">pessoa a remover</param>
        public void DeletePessoa(double nif)
        {
            marca.Concessionarios.Find(var => var.SearchPessoa(nif) == true).DeletePessoa(nif);
        }
        #endregion

        /// <summary>
        /// Metodo que exporta os dados para um ficheiro
        /// </summary>
        public void Export()
        {
            Marca.ExportJson(marca, path);
        }
    }

}
