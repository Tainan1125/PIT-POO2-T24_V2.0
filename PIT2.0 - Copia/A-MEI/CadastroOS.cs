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
    public partial class CadastroOS : Form
    {
        public CadastroOS()
        {
            InitializeComponent();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void saidaDate_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarButton_Click(object sender, EventArgs e)
        {
            SqlConnection conexao = new SqlConnection();
            int linhasAfetadas = 0;

            Ordem_Serviço ordem = new Ordem_Serviço();
            ordem.Cliente.Id = Cliente.CpfExiste(cpfText.Text);
            if (ordem.Cliente.Id != -1)
            {
                string item = itemText.Text;
                ordem.Item = item;
                string descricao = descricaoText.Text;
                ordem.Descrição = descricao;
                DateTime entrada = entradaDate.Value;
                ordem.Entrada = entrada;
                float valor = (float)valorNumber.Value;
                ordem.Valor = valor;

                if (pagoCKB.Checked)
                {
                    ordem.Pago = true;
                    if (saidaCKB.Checked)
                    {
                        DateTime saida = saidaDate.Value;
                        ordem.Saída = saida;
                        ordem.Retirado = true;
                    }
                }
                else
                {
                    ordem.Pago = false;
                }
                try
                {
                    if (ordem.Retirado == true)
                    {
                        SqlCommand sql = new SqlCommand();
                        conexao.ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=PIT;Integrated Security=True";
                        sql.Connection = conexao;
                        sql.CommandText = "INSERT INTO Ordem_Serviço (item, cliente, descricao, entrada, saida, valor, pago, retirado) VALUES " +
                            "(@item, @cliente, @descricao, @entrada, @saida, @valor, @pago, @retirado) ";
                        sql.Parameters.AddWithValue("@item", ordem.Item);
                        sql.Parameters.AddWithValue("@cliente", ordem.Cliente.Id);
                        sql.Parameters.AddWithValue("@descricao", ordem.Descrição);
                        sql.Parameters.AddWithValue("@entrada", ordem.Entrada);
                        sql.Parameters.AddWithValue("@saida", ordem.Saída);
                        sql.Parameters.AddWithValue("@valor", ordem.Valor);
                        sql.Parameters.AddWithValue("@pago", ordem.Pago);
                        sql.Parameters.AddWithValue("@retirado", ordem.Retirado);
                        conexao.Open();
                        linhasAfetadas = sql.ExecuteNonQuery();
                    }
                    else
                    {
                        SqlCommand sql = new SqlCommand();
                        conexao.ConnectionString = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=PIT;Integrated Security=True";
                        sql.Connection = conexao;
                        sql.CommandText = "INSERT INTO Ordem_Serviço (item, cliente, descricao, entrada, valor, pago, retirado) VALUES " +
                            "(@item, @cliente, @descricao, @entrada, @valor, @pago, @retirado) ";
                        sql.Parameters.AddWithValue("@item", ordem.Item);
                        sql.Parameters.AddWithValue("@cliente", ordem.Cliente.Id);
                        sql.Parameters.AddWithValue("@descricao", ordem.Descrição);
                        sql.Parameters.AddWithValue("@entrada", ordem.Entrada);
                        sql.Parameters.AddWithValue("@valor", ordem.Valor);
                        sql.Parameters.AddWithValue("@pago", ordem.Pago);
                        sql.Parameters.AddWithValue("@retirado", ordem.Retirado);
                        conexao.Open();
                        linhasAfetadas = sql.ExecuteNonQuery();
                    }
                }
                catch(Exception exception)
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
                MessageBox.Show("Cliente inválido!");
            }
        }
        private void listarButton_Click(object sender, EventArgs e)
        {
            var form = new ListagemOS();
            form.Show();
        }

        private void removerButton_Click(object sender, EventArgs e)
        {
            int id = (int)idNumber.Value;

            if (OSRepositorio.Remover(id))
            {
                MessageBox.Show("Ordem removida com sucesso.");
            }
            else
            {
                MessageBox.Show("Não foi possível remover esta Ordem de Serviço!");
            }
        }

        private void CadastroOS_Load(object sender, EventArgs e)
        {

        }

        private void pagoCKB_CheckedChanged(object sender, EventArgs e)
        {
            if (pagoCKB.Checked)
            {
                saidaCKB.Enabled = true;
            }
            else
            {
                saidaCKB.Enabled = false;
                saidaCKB.Checked = false;
            }
        }

        private void saidaCKB_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
