using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using promos.DAO;
using System.Data;

namespace promos.DAO
{
    public class HelperDAO
    {
        public static void ExecutaSQL(string sql, SqlParameter[] parametros)
        {
            using (SqlConnection conexao = ConexaoBD.GetConexao())
            {
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                {
                    comando.Parameters.AddRange(parametros);
                    comando.ExecuteNonQuery();
                }
                conexao.Close();
            }
        }
    }
}
