using Senha.Negocios;
using Senha.Objetos;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Senha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        GravarConexao gravarConexao;
        AlterarConexao alterarConexao;
        ExcluirConexao excluirConexao;
        ListarConexao listarConexao;
        TS ts;

        int idTs = 0;
        string strPesquisa = string.Empty;
        private void Lancamento(char opc)
        {
            gravarConexao = new GravarConexao();
            alterarConexao = new AlterarConexao();
            excluirConexao = new ExcluirConexao();
            ts = new TS();
            try
            {
                ts.Id = idTs;
                ts.Empresa = TxtEmpresa.Text.Trim();
                ts.Nome = TxtUsuario.Text.Trim();
                ts.Senha = TxtSenha.Text.Trim();
                ts.Dominio = TxtDominio.Text.Trim();
                ts.Descricao = TxtDescricao.Text.Trim();

                switch (opc)
                {
                    case 'g':
                        gravarConexao.Gravar(ts);
                        break;
                    case 'a':
                        alterarConexao.Alterar(ts);
                        break;
                    case 'e':
                        excluirConexao.Excluir(ts);
                        break;
                    default:
                        MessageBox.Show("Opção inválida", "Erro");
                        break;
                }
                Pesquisa(TxtPesquisa.Text.Trim());
                Limpar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void Limpar()
        {
            TxtEmpresa.Clear();
            TxtUsuario.Clear();
            TxtSenha.Clear();
            TxtDominio.Clear();
            TxtDescricao.Clear();
            BtnAlterar.IsEnabled = false;
            BtnExcluir.IsEnabled = false;
            BtnGravar.IsEnabled = true;
        }
        private void Pesquisa(string pesquisa)
        {

            listarConexao = new ListarConexao();
            try
            {
                strPesquisa = "%" + pesquisa + "%";
                DGrdResultado.DataContext = listarConexao.Lista(strPesquisa).DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void WinPrincipal_Loaded(object sender, RoutedEventArgs e)
        {
            Pesquisa(TxtPesquisa.Text.Trim());
            TxtPesquisa.Focus();
        }

        private void BtnGravar_Click(object sender, RoutedEventArgs e)
        {
            Lancamento('g');
        }

        private void BtnAlterar_Click(object sender, RoutedEventArgs e)
        {
            Lancamento('a');
        }

        private void BtnExcluir_Click(object sender, RoutedEventArgs e)
        {
            Lancamento('e');
        }

        private void TxtPesquisa_TextChanged(object sender, TextChangedEventArgs e)
        {
            Pesquisa(TxtPesquisa.Text.Trim());
        }

        private void DGrdResultado_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                var rowView = DGrdResultado.SelectedItems[0] as DataRowView;

                idTs = int.Parse(rowView["Id"].ToString());
                TxtEmpresa.Text = rowView["Empresa_Usuario"].ToString();
                TxtDominio.Text = rowView["Dominio_Usuario"].ToString();
                TxtUsuario.Text = rowView["Nome_Usuario"].ToString();
                TxtSenha.Text = rowView["Senha_Usuario"].ToString();
                TxtDescricao.Text = rowView["Descricao"].ToString();

                BtnAlterar.IsEnabled = true;
                BtnExcluir.IsEnabled = true;
                BtnGravar.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
