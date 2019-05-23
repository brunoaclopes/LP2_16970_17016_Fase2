/*
*  -------------------------------------------------
* <copyright file=" Carro " company="IPCA"/>
* <date> 5/6/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using System;

namespace ClassLibrary
{
    /// <summary>
    /// Nesta classe estão definidos os atributos de um carro assim como metodos que premitem operar tais atributos.
    /// </summary>
    [Serializable]
    public class Carro
    {
        #region Atributos
        private DateTime data;
        private string modelo;
        private int vin;
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor com valores por defeito.
        /// </summary>
        public Carro()
        {
            modelo = "Exemplar";
            vin = 0;
            data = DateTime.Now;
        }

        /// <summary>
        /// Construtor com valores do exterior e data atual.
        /// </summary>
        /// <param name="modelo">modelo do veiculo</param>
        /// <param name="vin">vin do veiculo</param>
        public Carro(string modelo, int vin)
        {
            data = DateTime.Now;
            this.modelo = modelo;
            this.vin = vin;
        }

        /// <summary>
        /// Construtor com valores do exterior.
        /// </summary>
        /// <param name="data">data do veiculo</param>
        /// <param name="modelo">modelo do veiculo</param>
        /// <param name="vin">vin do veiculo</param>
        public Carro(DateTime data, string modelo, int vin)
        {
            this.data = data;
            this.modelo = modelo;
            this.vin = vin;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para a data do veiculo.
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
        /// Propriedade para o modelo do veiculo.
        /// </summary>
        public string Modelo
        {
            get { return modelo; }
            set { modelo = value; }
        }

        /// <summary>
        /// Propriedade que retorna o vin do veiculo.
        /// </summary>
        public int Vin
        {
            get { return vin; }
        }
        #endregion

        #region OVERRIDES

        public override bool Equals(Object obj)
        {
            return (this.vin == ((Carro)obj).vin);
        }

        public override string ToString()
        {
            return string.Format("Modelo= {0} - VIN= {1} - Data do Veiculo= {2}", modelo, vin, data.ToString("d"));
        }
        #endregion
    }

}