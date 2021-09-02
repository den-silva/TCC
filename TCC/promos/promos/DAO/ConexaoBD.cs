using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace promos.DAO
{
    public static class ConexaoBD
    {
        /// <summary>
        /// Método Estático que retorna um conexao aberta com o BD
        /// </summary>
        /// <returns>Conexão aberta</returns>
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_promos;Integrated Security=true";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            
            return conexao;
        }
    }
}