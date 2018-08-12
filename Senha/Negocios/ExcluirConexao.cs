using Senha.Conexao;
using Senha.Objetos;
using System;
using System.Data;
using System.Text;

namespace Senha.Negocios
{
    class ExcluirConexao
    {
        CRUD crud;
        StringBuilder sqlBuilder;

        public bool Excluir(TS ts)
        {
            crud = new CRUD();
            sqlBuilder = new StringBuilder();
            sqlBuilder.Append("DELETE FROM Senha ");
            sqlBuilder.Append("WHERE Id = @Id");
            try
            {
                crud.LimparParametro();
                crud.AdicionarParamentro("Id", ts.Id);
                crud.Executar(CommandType.Text, sqlBuilder.ToString());
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
