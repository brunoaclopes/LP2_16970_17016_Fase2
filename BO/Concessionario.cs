/*
*  -------------------------------------------------
* <copyright file=" Concessionario " company="IPCA"/>
* <date> 5/6/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using System;
using Newtonsoft.Json;

namespace BO
{
    /// <summary>
    /// Nesta Classe podemos encontrar como atributos Pessoas que por si contem uma lista de comerciais e uma de clientes do concessionario e Carros que comtem uma lista de carro, podemos tmb verificar que esta classe dispoem de um id, que corresponde ao ID do concessionario, e dos varios metodos desenvolvidos para manipular as anteriormente referidas listas.
    /// </summary>
    [Serializable]
    public class Concessionario: IPessoas, ICarros
    {
        #region Atributos
        private int id;
        private Pessoas p = new Pessoas();
        private Carros c = new Carros();
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor apenas com id
        /// </summary>
        /// <param name="id">id do concessinario</param>
        public Concessionario(int id)
        {
            this.id = id;
        }

        /// <summary>
        /// Construtor iniciado por uma pessoa ou carro
        /// </summary>
        /// <param name="id">id do concessinario</param>
        /// <param name="o">objeto a adicionar</param>
        public Concessionario(int id, object o)
        {
            this.id = id;

            if (o.GetType() == typeof(Carro))
            {
                c.AddCarro((Carro)o);
            }
            else if ((o.GetType() == typeof(Cliente)) || (o.GetType() == typeof(Comercial)))
            {
                p.AddPessoa(o);
            }
        }

        /// <summary>
        /// Construtor Completo
        /// </summary>
        /// <param name="id">ID do concessionario</param>
        /// <param name="p">lista de pessoas</param>
        /// <param name="c">lista de carros</param>
        [JsonConstructor]
        public Concessionario(int id, Pessoas p, Carros c)
        {
            this.id = id;
            this.c = c;
            this.p = p;
        }

        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade do ID do concessionario
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        /// <summary>
        /// Propriedade das pessoas
        /// </summary>
        public Pessoas Pessoas
        {
            get { return p; }
            set { p = value; }
        }

        /// <summary>
        /// Propriedade dos carros
        /// </summary>
        public Carros Carros
        {
            get { return c; }
            set { c = value; }
        }

        #region Propriedades Contadores
        /// <summary>
        /// Propriedade para o numero de carros do concessionario
        /// </summary>
        public int NCarros
        {
            get { if (c != null) return c.NCarros(); else return 0; }
        }

        /// <summary>
        /// Propriedade para o numero de clientes do concessionario
        /// </summary>
        public int NClientes
        {
            get { if (p != null) return p.Clientes.Count; else return 0; }
        }

        /// <summary>
        /// Propriedade para o numero de comerciais do concessionario
        /// </summary>
        public int NComerciais
        {
            get { if (p != null) return p.Comerciais.Count; else return 0; }
        }
        #endregion

        #endregion

        #region Metodos

        #region Metodos de Pessoas
        /// <summary>
        /// Metodo para adicionar um carro a um cliente
        /// </summary>
        /// <param name="nif">nif do cliente</param>
        /// <param name="c">veiculo a adicionar</param>
        /// <returns></returns>
        public bool AddCarro(double nif, Carro c)
        {
            return (p.AddCarro(nif, c));
        }

        /// <summary>
        /// Metodo para adicionar uma pessoa (Cliente/Comercial) á lista.
        /// </summary>
        /// <param name="p">objeto a adicionar</param>
        public bool AddPessoa(object p)
        {
            try
            {
                return (this.p.AddPessoa(p));
            }
            catch (NullReferenceException e)
            {
                this.p = new Pessoas(p);
                return true;
            }
            
        }

        /// <summary>
        /// Metodo para remover um carro de um cliente pelo vin do veiculo
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        public bool DeleteCarroClientes(int vin)
        {
            return (p.DeleteCarro(vin));
        }

        /// <summary>
        /// Metodo para apagar uma pessoa da lista.
        /// </summary>
        /// <param name="nif">NIF da Pessoa</param>
        /// <returns></returns>
        public bool DeletePessoa(double nif)
        {
            return (p.DeletePessoa(nif));
        }

        /// <summary>
        /// Metodo que retorna os carros de um cliente pelo seu nif
        /// </summary>
        /// <param name="nif">NIF do cliente a consultar</param>
        /// <returns></returns>
        public Carros GetCarros(double nif)
        {
            return (p.GetCarros(nif));
        }

        /// <summary>
        /// Metodo para listar todos os clientes e comerciais.
        /// </summary>
        public void ListPessoas()
        {
            p.ListPessoas();
        }

        /// <summary>
        /// Metodo que lista pessoas pelo tipo (Cliente ou Comercial).
        /// </summary>
        /// <param name="x">Tipo de pessoas a listar</param>
        public void ListPessoas(TipoDePessoa x)
        {
            p.ListPessoas(x);
        }

        /// <summary>
        /// Metodo que procura e retorna se uma pessoa existe ou nao na lista com saida atravez de um parametro caso exista. 0= Cliente, 1=Comercial e -1=Nao encontrada. 
        /// </summary>
        /// <param name="nif">NIF da Pessoa</param>
        /// <param name="p">Parametro de saida do objeto caso seja encontrado</param>
        /// <returns></returns>
        public int SearchPessoa(double nif, out object p)
        {
            return (this.p.SearchPessoa(nif, out p));
        }

        /// <summary>
        /// Metodo que procura e retorna se uma pessoa existe ou nao na lista.
        /// </summary>
        /// <param name="nif">Nif da Pessoa</param>
        /// <returns></returns>
        public bool SearchPessoa(double nif)
        {
            return (p.SearchPessoa(nif));
        }

        #endregion

        #region Metodos de Carros
        /// <summary>
        /// Metodo para adicionar um carro a lista.
        /// </summary>
        /// <param name="c">objeto tipo Carro a adicionar</param>
        public bool AddCarro(Carro c)
        {
            try
            {
                return this.c.AddCarro(c);
            }
            catch (NullReferenceException e)
            {
                this.c = new Carros(c);
                return true;
            }
        }

        /// <summary>
        /// Metodo para apagar um carro da lista.
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        public bool DeleteCarro(int vin)
        {
            return (c.DeleteCarro(vin));
        }

        /// <summary>
        /// Metodo para listar tds os carros de uma lista.
        /// </summary>
        public void ListCarros()
        {
            c.ListCarros();
        }

        /// <summary>
        /// Metodo que procura e retorna se um carro existe ou nao na lista com saida atravez de um parametro caso exista. 
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <param name="c">Parametro de saido do objeto carro caso seja encontrado</param>
        /// <returns></returns>
        public bool SearchCarro(int vin, out Carro c)
        {
            return (this.c.SearchCarro(vin, out c));
        }

        /// <summary>
        /// Metodo que procura e retorna se um carro existe ou nao no array. 
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        public bool SearchCarro(int vin)
        {
            return (c.SearchCarro(vin));
        }
        #endregion

        #endregion
    }
}