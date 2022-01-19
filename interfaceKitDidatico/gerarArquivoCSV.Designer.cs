namespace interfaceKitDidatico
{
    partial class gerarArquivoCSV
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
            this.iniciarVerificacao = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // iniciarVerificacao
            // 
            this.iniciarVerificacao.Location = new System.Drawing.Point(134, 158);
            this.iniciarVerificacao.Name = "iniciarVerificacao";
            this.iniciarVerificacao.Size = new System.Drawing.Size(142, 23);
            this.iniciarVerificacao.TabIndex = 7;
            this.iniciarVerificacao.Text = "Gerar Arquivo";
            this.iniciarVerificacao.UseVisualStyleBackColor = true;
            this.iniciarVerificacao.Click += new System.EventHandler(this.gerarCSV);
            // 
            // gerarArquivoCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 341);
            this.Controls.Add(this.iniciarVerificacao);
            this.Name = "gerarArquivoCSV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "gerarArquivoCSV";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button iniciarVerificacao;
    }
}