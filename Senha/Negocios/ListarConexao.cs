using Senha.Conexao;
using System;
using System.Data;
using System.Text;

namespace Senha.Negocios
{
    class ListarConexao
    {
        CRUD crud;
        StringBuilder sqlBuilder;

        public DataTable Lista(string pesquisa)
        {
            crud = new CRUD();
            sqlBuilder = new StringBuilder();
            sqlBuilder.Append("SELECT Id, Empresa_Usuario, Nome_Usuario, Senha_Usuario, Dominio_Usuario, Descricao ");
            sqlBuilder.Append("FROM Senha ");
            sqlBuilder.Append("WHERE Empresa_Usuario LIKE @Empresa_Usuario OR Nome_Usuario LIKE @Nome_Usuario OR Descricao LIKE @Descricao");
            try
            {
                crud.LimparParametro();
                crud.AdicionarParamentro("Empresa_Usuario", pesquisa);
                crud.AdicionarParamentro("Nome_Usuario", pesquisa);
                crud.AdicionarParamentro("Descricao", pesquisa);

                DataTable dataTable = crud.Consulta(CommandType.Text, sqlBuilder.ToString());
                return dataTable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
