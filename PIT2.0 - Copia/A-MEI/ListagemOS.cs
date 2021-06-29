using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KomsertaPC_OS_s
{
    public partial class ListagemOS : Form
    {
        public ListagemOS()
        {
            InitializeComponent();
        }
        private void osListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ListagemOS_Load(object sender, EventArgs e)
        {
            listagemOrdem_Serviço.DataSource = Ordem_Serviço.PopularOrdem_Serviço();
        }
    }
}
