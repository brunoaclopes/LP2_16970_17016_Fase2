/*
*  -------------------------------------------------
* <copyright file=" Marca " company="IPCA"/>
* <date> 5/6/2019 </date>
* <author1> Bruno Lopes 16970</author1>
* <author2> Ines Alves 17016 </author2>
* <email> a16970@alunos.ipca.pt </email>
* -------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace ClassLibrary
{
    /// <summary>
    /// Esta classe contem o nome da marca e uma lista de concessionarios pertencentes a determinada marca, assim como metodos para operar a lista de concessionarios, uma propriedades para operar com o nome da marca e futuramente ira dispor de metodos para trabalhar com ficheiros de dados.
    /// </summary>
    [Serializable]
    public class Marca
    {
        #region Atributos
        private string nome;
        private List<Concessionario> cons = new List<Concessionario>();
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor com valores por defeito
        /// </summary>
        public Marca()
        {
            nome = "BMW";
        }

        /// <summary>
        /// Construtor com nome da marca vindo do exterior
        /// </summary>
        /// <param name="nome">nome da marca</param>
        public Marca(string nome)
        {
            this.nome = nome;
        }
        #endregion

        #region Propriedades
        /// <summary>
        /// Propriedade para o nome da marca
        /// </summary>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        #endregion

        #region Metodos

        public bool AddConc (Concessionario c)
        {
            if (!cons.Exists(var => var.Id == c.Id))
            {
                cons.Add(c);
                return true;
            }
            return false;
        }


        public bool DeleteConc(int id)
        {
            if (cons.Exists(var => var.Id == id))
            {
                cons.Remove(cons.Find(var => var.Id == id));
                return true;
            }
            return false;
        }

        public bool SearchConc (int id, out Concessionario c)
        {
            c = null;
            if (cons.Exists(var => var.Id == id))
            {
                c = cons.Find(var => var.Id == id);
                return true;
            }
            return false;
        }

        #endregion

        #region Metodos Ficheiros
        /// <summary>
        /// Metodo para Exportar um objeto Marca para um ficheiro Json
        /// </summary>
        /// <param name="m">objeto a exportar</param>
        /// <param name="path">caminho do ficheiro</param>
        public static void ExportJson(Marca m, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, m);
            }
        }

        /// <summary>
        /// Metodo para Importar um objeto Marca de um ficheiro Json
        /// </summary>
        /// <param name="m">objeto a importar</param>
        /// <param name="path">caminho do ficheiro</param>
        public static void ImportJson(out Marca m, string path)
        {
            using (StreamReader file = File.OpenText(@path))
            {
                JsonSerializer serializer = new JsonSerializer();
                m = (Marca)serializer.Deserialize(file, typeof(Marca));
            }
        }

        #endregion
    }
}