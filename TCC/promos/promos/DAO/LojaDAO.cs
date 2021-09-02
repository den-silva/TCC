using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using promos.Models;

namespace promos.DAO
{
    public class LojaDAO
    {
        private SqlParameter[] CriaParametros(LojaViewModel loja)
        {
            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter("id", loja.id);
            parametros[1] = new SqlParameter("nome", loja.cnpj);
            parametros[2] = new SqlParameter("mensalidade", loja.matriz);
            parametros[3] = new SqlParameter("cidadeId", loja.nome);
            parametros[4] = new SqlParameter("dataNascimento", loja.funciona);
            return parametros;
        }
        /// <summary>
        /// Método para inserir um aluno no BD
        /// </summary>
        /// <param name="aluno">objeto aluno com todas os atributos preenchidos</param>
        public void Inserir(LojaViewModel loja)
        {
            string sql =
            "insert into tb_loja(id, cnpj, matriz, nome, funciona)" +
            "values ( @id, @cnpj, @matriz, @nome, @funciona)";
            HelperDAO.ExecutaSQL(sql, CriaParametros(loja));
        }
        /// <summary>
        /// Altera um aluno no banco de dados
        /// </summary>
        /// <param name="aluno">objeto aluno com todas os atributos preenchidos</param>
        public void Alterar(LojaViewModel loja
            )
        {
            string sql =
            "update tb_loja set matriz=@matriz, nome=@nome, funciona=@funciona";
            HelperDAO.ExecutaSQL(sql, CriaParametros(loja));
        }
        /// <summary>
        /// Exclui um aluno no banco de dados.
        /// </summary>
        /// <param name="id">id do aluno</param>
        public void Excluir(int id)
        {
            string sql = "delete tb_loja where id =" + id;
            HelperDAO.ExecutaSQL(sql, null);
        }
    }
}

