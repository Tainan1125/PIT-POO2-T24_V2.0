using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace KomsertaPC_OS_s
{
    public partial class CadastroCliente : Form
    {
        public CadastroCliente()
        {
            InitializeComponent();
        }

        private void cadastrarButton_Click(object sender, EventArgs e)
        {
            Cliente cliente;
            SqlConnection conexao = new SqlConnection();
            int linhasAfetadas = 0;
            if (nomeText.Text.Trim().Length > 0)
            {
                try
                {
                    cliente = Cliente.Create(nomeText.Text, cpfText.Text, telefoneText.Text);
                    SqlCommand sql = new SqlCommand();
                    conexao.ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=PIT;Integrated Security=True";
                    sql.Connection = conexao;
                    sql.CommandText = "INSERT INTO Cliente (nome, cpf, telefone) VALUES " +
                        "(@nome, @cpf, @telefone) ";
                    sql.Parameters.AddWithValue("@nome", cliente.Nome);
                    sql.Parameters.AddWithValue("@cpf", cliente.Cpf.getCpf());
                    sql.Parameters.AddWithValue("@telefone", cliente.Telefone);
                    conexao.Open();
                    linhasAfetadas = sql.ExecuteNonQuery();
                }
                catch (Exception exception)
                {

                    MessageBox.Show(exception.Message);
                }
                finally
                {
                     conexao.Close();
                     MessageBox.Show($"Cliente registrado com sucesso.\n" +
                            $"Linhas afetadas: {linhasAfetadas}");
                }

            }
            else
            {
                MessageBox.Show("Preencha os campos!");
            }
        }

        private void removerButton_Click(object sender, EventArgs e)
        {
   
        }

        private void listarButton_Click(object sender, EventArgs e)
        {
            var form = new ListagemClientes();
            form.Show();
        }

        private void CadastroCliente_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
