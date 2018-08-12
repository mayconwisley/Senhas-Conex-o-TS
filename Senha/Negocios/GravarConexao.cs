using Senha.Conexao;
using Senha.Objetos;
using System;
using System.Data;
using System.Text;

namespace Senha.Negocios
{
    class GravarConexao
    {
        CRUD crud;
        StringBuilder sqlBuilder;

        public bool Gravar(TS ts)
        {
            crud = new CRUD();
            sqlBuilder = new StringBuilder();
            sqlBuilder.Append("INSERT INTO Senha (Empresa_Usuario, Nome_Usuario, Senha_Usuario, Dominio_Usuario, Descricao) ");
            sqlBuilder.Append("VALUES (@Empresa_Usuario, @Nome_Usuario, @Senha_Usuario, @Dominio_Usuario, @Descricao)");

            try
            {
                crud.LimparParametro();
                crud.AdicionarParamentro("Empresa_Usuario", ts.Empresa);
                crud.AdicionarParamentro("Nome_Usuario", ts.Nome);
                crud.AdicionarParamentro("Senha_Usuario", ts.Senha);
                crud.AdicionarParamentro("Dominio_Usuario", ts.Dominio);
                crud.AdicionarParamentro("Descricao", ts.Descricao);
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
