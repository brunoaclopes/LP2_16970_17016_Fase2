/*
*  -------------------------------------------------
* <copyright file=" BusinessLayer " company="IPCA"/>
* <date> 5/27/2019 10:56:28 AM </date>
* <author> bruno </author>
* <email> a16970@alunos.ipca.pt </email>
* <desc>
*   
* </desc>
* -------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DL;

namespace BL
{
    /// <summary>
    /// Classe que controla o acesso aos dados
    /// </summary>
    public class BusinessLayer
    {
        private DataLayer data;

        #region Construtores
        /// <summary>
        /// Construtor de BusinessLayer
        /// </summary>
        public BusinessLayer()
        {
            data = new DataLayer();
        }
        #endregion

        #region Metodos
        
        /// <summary>
        /// Metodo que fornece o nome da marca
        /// </summary>
        /// <returns></returns>
        public string NomeMarca()
        {
            return data.NomeMarca();
        }

        #region Contadores
        /// <summary>
        /// Conta o numero total de Concessionarios da marca
        /// </summary>
        /// <returns></returns>
        public int NConcessionarios()
        {
            return data.NConcessionarios();
        }

        /// <summary>
        /// Conta o numero total de Carros em stock da marca
        /// </summary>
        /// <returns></returns>
        public int NCarros()
        {
            return data.NCarros();
        }

        /// <summary>
        /// Conta o numero de carros de um determinado cliente
        /// </summary>
        /// <param name="nif">NIF do cliente</param>
        /// <returns></returns>
        public int NCarros(double nif)
        {
            return data.NCarros(nif);
        }

        /// <summary>
        /// Conta o numero total de Comerciais da marca
        /// </summary>
        /// <returns></returns>
        public int NComerciais()
        {
            return data.NComerciais();
        }

        /// <summary>
        /// Conta o numero total de Clientes da marca
        /// </summary>
        /// <returns></returns>
        public int NClientes()
        {
            return data.NClientes();
        }
        #endregion

        #region Metodos Concessionarios
        /// <summary>
        /// Metodo que fornece uma lista com os concessionarios
        /// </summary>
        /// <returns></returns>
        public List<Concessionario> Concessionarios()
        {
            return data.Concessionarios();
        }

        /// <summary>
        /// Metodo para adicionar um novo concessionario
        /// </summary>
        public void AddConcessionario()
        {
            int id;
            if (data.Concessionarios().Count != 0) id = data.Concessionarios().Max<Concessionario>(var => var.Id) + 1; else id = 1;
            data.AddConcessionario(id);
        }

        /// <summary>
        /// Metodo para remover um concessionario
        /// </summary>
        /// <param name="id"></param>
        public void DeleteConcessionario(int id)
        {
            data.DeleteConcessionario(id);
        }
        #endregion

        #region Metodos Carros
        /// <summary>
        /// Metodo que retorna a lista de carros de um determinado concessionario
        /// </summary>
        /// <param name="id">id fo concessionario</param>
        /// <returns></returns>
        public List<Carro> ListaCarros (int id)
        {
            try
            {
                return data.Carros(id).LCarros;
            }
            catch (NullReferenceException e)
            {
                return null;
            }
            
        }

        /// <summary>
        /// Metodo para adicionar um carro a um determinado concessioario
        /// </summary>
        /// <param name="id">id do concessionario</param>
        /// <param name="data">data do carro</param>
        /// <param name="modelo">modelo do carro</param>
        /// <param name="vin">vin do carro</param>
        public void AddCarro(int id, DateTime data, string modelo, int vin)
        {
            this.data.AddCarro(id, new Carro(data, modelo, vin));
        }

        /// <summary>
        /// Metodo para remover um carro de uma determinada lista
        /// </summary>
        /// <param name="vin">vin do carro a remover</param>
        public void DeleteCarro(int vin)
        {
            data.DeleteCarro(vin);
        }

        #endregion

        #region Metodos Pessoas
        /// <summary>
        /// Metodo que retorna a lista de comerciais de um determinado cocessionario
        /// </summary>
        /// <param name="id">id do concessionario</param>
        /// <returns></returns>
        public List<Comercial> ListaComerciais(int id)
        {
            try
            {
                return data.Pessoas(id).Comerciais;
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo que retorna a lista de clientes de um determinado cocessionario
        /// </summary>
        /// <param name="id">id do concessionario</param>
        /// <returns></returns>
        public List<Cliente> ListaClientes(int id)
        {
            try
            {
                return data.Pessoas(id).Clientes;
            }
            catch (NullReferenceException e)
            {
                return null;
            }
        }

        /// <summary>
        /// Metodo para adicionar uma pessoa a um concessionario
        /// </summary>
        /// <param name="id">id do concessionario</param>
        /// <param name="o">pessoa a adicionar</param>
        public void AddPessoa(int id, object o)
        {
            this.data.AddPessoa(id, o);
        }

        /// <summary>
        /// Metodo para remover uma pessoa
        /// </summary>
        /// <param name="nif">nif da pessoa</param>
        public void DeletePessoa(double nif)
        {
            data.DeletePessoa(nif);
        }

        #endregion

        /// <summary>
        /// Metodo que exporta os dados para um ficheiro
        /// </summary>
        public void Export()
        {
            data.Export();
        }

        #endregion
    }
}
