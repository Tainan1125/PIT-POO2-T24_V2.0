using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KomsertaPC_OS_s
{
    public partial class ListagemClientes : Form
    {
        public ListagemClientes()
        {
            InitializeComponent();
        }

        private void ListagemCliente_Load(object sender, EventArgs e)
        {
            listagemCliente.DataSource = Cliente.PopularCliente();
        }
        private void clienteListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
