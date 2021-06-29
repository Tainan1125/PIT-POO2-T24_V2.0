
namespace KomsertaPC_OS_s
{
    partial class ListagemOS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listagemOrdem_Serviço = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.listagemOrdem_Serviço)).BeginInit();
            this.SuspendLayout();
            // 
            // listagemOrdem_Serviço
            // 
            this.listagemOrdem_Serviço.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.listagemOrdem_Serviço.Location = new System.Drawing.Point(12, 12);
            this.listagemOrdem_Serviço.Name = "listagemOrdem_Serviço";
            this.listagemOrdem_Serviço.RowTemplate.Height = 25;
            this.listagemOrdem_Serviço.Size = new System.Drawing.Size(760, 337);
            this.listagemOrdem_Serviço.TabIndex = 0;
            // 
            // ListagemOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.listagemOrdem_Serviço);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ListagemOS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "A-MEI - ListagemOS";
            this.Load += new System.EventHandler(this.ListagemOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listagemOrdem_Serviço)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView listagemOrdem_Serviço;
    }
}