using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DAO
{
    public static class ConexaoBD
    {
        /// <summary>
        /// Método Estático que retorna um conexao aberta com o BD
        /// </summary>
        /// <returns>Conexão aberta</returns>
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=LOCALHOST;Initial Catalog=db_promos;user id=sa; password=123456";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            
            return conexao;
        }
    }
}