/*
*  -------------------------------------------------
* <copyright file=" Pessoas " company="IPCA"/>
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
    /// Este enumerado serve para reservar as palavras Cliente e Comercial que serao futuramente utilizadas no controlo de metodos.
    /// </summary>
    public enum TipoDePessoa
    {
        Cliente,
        Comercial
    }


    /// <summary>
    /// Esta classe dispoem de uma lista de cliente e uma de comercial assim como varios metodos para manipular essas listas.
    /// </summary>
    [Serializable]
    public class Pessoas
    {
        #region Atributos
        private List<Cliente> cl = new List<Cliente>();
        private List<Comercial> cm = new List<Comercial>();
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade da lista de comerciais
        /// </summary>
        public List<Comercial> Comerciais
        {
            get { return cm; }
        }

        /// <summary>
        /// Propriedade da lista de clientes
        /// </summary>
        public List<Cliente> Clientes
        {
            get { return cl; }
        }
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor vazio
        /// </summary>
        public Pessoas()
        {
        }

        /// <summary>
        /// Construtor com cliente ou comercial fornecido do exterior, objeto só é adicionado caso ainda não exista já na lista.
        /// </summary>
        /// <param name="p">pessoa a adiconar a lista</param>
        public Pessoas(object p)
        {
            AddPessoa(p);
        }

        #endregion
        
        #region Metodos

        #region Metodos gerais
        /// <summary>
        /// Metodo para adicionar uma pessoa (Cliente/Comercial) á lista.
        /// </summary>
        /// <param name="p">objeto a adicionar</param>
        public bool AddPessoa(object p)
        {
            if (p.GetType() == typeof(Cliente))
            {
                if (!cl.Exists(var => var.Nif == ((Cliente)p).Nif))
                {
                    cl.Add(((Cliente)p));
                    return true;
                }
                return false;
            }
            else if(p.GetType() == typeof(Comercial))
            {
                if (!cm.Exists(var => var.Nif == ((Comercial)p).Nif))
                {
                    cm.Add(((Comercial)p));
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Metodo para apagar uma pessoa da lista.
        /// </summary>
        /// <param name="nif">NIF da Pessoa</param>
        /// <returns></returns>
        public bool DeletePessoa(double nif)
        {
            if (cl.Exists(var => var.Nif == nif))
            {
                cl.Remove(cl.Find(var => var.Nif == nif));
                return true;
            }
            else if (cm.Exists(var => var.Nif == nif))
            {
                cm.Remove(cm.Find(var => var.Nif == nif));
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que procura e retorna se uma pessoa existe ou nao na lista com saida atravez de um parametro caso exista. 0= Cliente, 1=Comercial e -1=Nao encontrada. 
        /// </summary>
        /// <param name="nif">NIF da Pessoa</param>
        /// <param name="p">Parametro de saida do objeto caso seja encontrado</param>
        /// <returns></returns>
        public int SearchPessoa(double nif, out object p)
        {
            p = null;
            if (cl.Exists(var => var.Nif == nif))
            {
                p = cl.Find(var => var.Nif == nif);
                return 0;
            }
            else if (cm.Exists(var => var.Nif == nif))
            {
                p = cm.Find(var => var.Nif == nif);
                return 1;
            }
            return -1;
        }

        /// <summary>
        /// Metodo que procura e retorna se uma pessoa existe ou nao na lista.
        /// </summary>
        /// <param name="nif">Nif da Pessoa</param>
        /// <returns></returns>
        public bool SearchPessoa(double nif)
        {
            return ((cl.Exists(var => var.Nif == nif)) || (cm.Exists(var => var.Nif == nif)));
        }

        /// <summary>
        /// Metodo para listar todos os clientes e comerciais.
        /// </summary>
        public void ListPessoas()
        {
            Console.WriteLine();
            Console.WriteLine("Clientes:");
            foreach (Pessoa var in cl)
            {
                Console.WriteLine(var.ToString());
            }
            Console.WriteLine("\nComercias:");
            foreach (Pessoa var in cm)
            {
                Console.WriteLine(var.ToString());
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Metodo que lista pessoas pelo tipo (Cliente ou Comercial).
        /// </summary>
        /// <param name="x">Tipo de pessoas a listar</param>
        public void ListPessoas(TipoDePessoa x)
        {
            Console.WriteLine();
            if (x == TipoDePessoa.Cliente)
            {
                Console.WriteLine("Clientes:");
                foreach (Pessoa var in cl)
                {
                    Console.WriteLine(var.ToString());
                }
            } else
            {
                Console.WriteLine("Comercias:");
                foreach (Pessoa var in cm)
                {
                    Console.WriteLine(var.ToString());
                }
            }
            Console.WriteLine();
        }
        #endregion

        #region Metodos de Cliente (Gestao de carros)
        /// <summary>
        /// Metodo para adicionar um carro a um cliente
        /// </summary>
        /// <param name="nif">nif do cliente</param>
        /// <param name="c">veiculo a adicionar</param>
        /// <returns></returns>
        public bool AddCarro(double nif, Carro c)
        {
            if (cl.Exists(var => var.Nif == nif))
            {
                cl[cl.IndexOf(cl.Find(var => var.Nif == nif))].AddCarro(c);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo para remover um carro de um cliente pelo vin do veiculo
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        public bool DeleteCarro(int vin)
        {
            if (cl.Exists(var => var.SearchCarro(vin) == true))
            {
                cl[cl.IndexOf(cl.Find(var => var.SearchCarro(vin) == true))].DeleteCarro(vin);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Metodo que retorna os carros de um cliente pelo seu nif
        /// </summary>
        /// <param name="nif">NIF do cliente a consultar</param>
        /// <returns></returns>
        public Carros GetCarros(double nif)
        {
            if (cl.Exists(var => var.Nif == nif))
            {
                return cl[cl.IndexOf(cl.Find(var => var.Nif == nif))].GetCarros();
            }
            return null;
        }
        #endregion

        #endregion
    }
}