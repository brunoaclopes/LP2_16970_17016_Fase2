/*
*  -------------------------------------------------
* <copyright file=" IPessoas " company="IPCA"/>
* <date> 5/6/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

namespace BO
{
    /// <summary>
    /// Esta interface foi desenvolvida meramente para auxiliar no desenvolvimento de classes que utilizem listas com pessoas.
    /// </summary>
    public interface IPessoas
    {
        #region Metodos gerais
        /// <summary>
        /// Metodo para adicionar uma pessoa (Cliente/Comercial) á lista.
        /// </summary>
        /// <param name="p">objeto a adicionar</param>
        bool AddPessoa(object p);

        /// <summary>
        /// Metodo para apagar uma pessoa da lista.
        /// </summary>
        /// <param name="nif">NIF da Pessoa</param>
        /// <returns></returns>
        bool DeletePessoa(double nif);

        /// <summary>
        /// Metodo que procura e retorna se uma pessoa existe ou nao na lista com saida atravez de um parametro caso exista. 0= Cliente, 1=Comercial e -1=Nao encontrada. 
        /// </summary>
        /// <param name="nif">NIF da Pessoa</param>
        /// <param name="p">Parametro de saida do objeto caso seja encontrado</param>
        /// <returns></returns>
        int SearchPessoa(double nif, out object p);

        /// <summary>
        /// Metodo que procura e retorna se uma pessoa existe ou nao na lista.
        /// </summary>
        /// <param name="nif">Nif da Pessoa</param>
        /// <returns></returns>
        bool SearchPessoa(double nif);

        /// <summary>
        /// Metodo para listar todos os clientes e comerciais.
        /// </summary>
        void ListPessoas();

        /// <summary>
        /// Metodo que lista pessoas pelo tipo (Cliente ou Comercial).
        /// </summary>
        /// <param name="x">Tipo de pessoas a listar</param>
        void ListPessoas(TipoDePessoa x);
        #endregion

        #region Metodos de Cliente (Gestao de carros)
        /// <summary>
        /// Metodo para adicionar um carro a um cliente
        /// </summary>
        /// <param name="nif">nif do cliente</param>
        /// <param name="c">veiculo a adicionar</param>
        /// <returns></returns>
        bool AddCarro(double nif, Carro c);

        /// <summary>
        /// Metodo para remover um carro de um cliente pelo vin do veiculo
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        bool DeleteCarroClintes(int vin);

        /// <summary>
        /// Metodo que retorna os carros de um cliente pelo seu nif
        /// </summary>
        /// <param name="nif">NIF do cliente a consultar</param>
        /// <returns></returns>
        Carros GetCarros(double nif);
        #endregion
    }
}