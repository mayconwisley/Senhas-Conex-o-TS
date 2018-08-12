using Senha.Conexao;
using Senha.Objetos;
using System;
using System.Data;
using System.Text;

namespace Senha.Negocios
{
    class AlterarConexao
    {
        CRUD crud;
        StringBuilder sqlBuilder;

        public bool Alterar(TS ts)
        {
            crud = new CRUD();
            sqlBuilder = new StringBuilder();
            sqlBuilder.Append("UPDATE Senha SET Empresa_Usuario = @Empresa_Usuario, Nome_Usuario = @Nome_Usuario, Senha_Usuario = @Senha_Usuario, ");
            sqlBuilder.Append("Dominio_Usuario = Dominio_Usuario, Descricao = @Descricao ");
            sqlBuilder.Append("WHERE Id = @Id");
            try
            {
                crud.LimparParametro();
                crud.AdicionarParamentro("Empresa_Usuario", ts.Empresa);
                crud.AdicionarParamentro("Nome_Usuario", ts.Nome);
                crud.AdicionarParamentro("Senha_Usuario", ts.Senha);
                crud.AdicionarParamentro("Dominio_Usuario", ts.Dominio);
                crud.AdicionarParamentro("Descricao", ts.Descricao);
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
