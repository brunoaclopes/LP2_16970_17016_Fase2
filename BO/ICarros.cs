/*
*  -------------------------------------------------
* <copyright file=" ICarros " company="IPCA"/>
* <date> 5/6/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

namespace BO
{
    /// <summary>
    /// Esta interface foi desenvolvida meramente para auxiliar no desenvolvimento de classes que utilizem uma lista de carros.
    /// </summary>
    public interface ICarros
    {
        /// <summary>
        /// Metodo para adicionar um carro a lista.
        /// </summary>
        /// <param name="c">objeto tipo Carro a adicionar</param>
        bool AddCarro(Carro c);

        /// <summary>
        /// Metodo para apagar um carro da lista.
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        bool DeleteCarro(int vin);

        /// <summary>
        /// Metodo que procura e retorna se um carro existe ou nao na lista com saida atravez de um parametro caso exista. 
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <param name="c">Parametro de saido do objeto carro caso seja encontrado</param>
        /// <returns></returns>
        bool SearchCarro(int vin, out Carro c);

        /// <summary>
        /// Metodo que procura e retorna se um carro existe ou nao no array. 
        /// </summary>
        /// <param name="vin">vin do veiculo</param>
        /// <returns></returns>
        bool SearchCarro(int vin);
        
        /// <summary>
        /// Metodo para listar tds os carros de uma lista.
        /// </summary>
        void ListCarros();
    }
}