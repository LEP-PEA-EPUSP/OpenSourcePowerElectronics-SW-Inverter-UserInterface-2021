namespace interfaceKitDidatico
{
    partial class Experimento2
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
            System.Windows.Forms.TextBox titleE2;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Vcc = new System.Windows.Forms.ComboBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Frequency = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonAvancar = new System.Windows.Forms.Button();
            this.NivelPWM = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonLiga = new System.Windows.Forms.Button();
            this.buttonDesliga = new System.Windows.Forms.Button();
            this.buttonAquisicao = new System.Windows.Forms.Button();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            titleE2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleE2
            // 
            titleE2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            titleE2.BackColor = System.Drawing.SystemColors.MenuBar;
            titleE2.CausesValidation = false;
            titleE2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            titleE2.Location = new System.Drawing.Point(50, 35);
            titleE2.Name = "titleE2";
            titleE2.ReadOnly = true;
            titleE2.Size = new System.Drawing.Size(400, 29);
            titleE2.TabIndex = 1;
            titleE2.TabStop = false;
            titleE2.Text = "Experimento 2 - Conversor Ponte H";
            titleE2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Vcc);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.Frequency);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.buttonAvancar);
            this.groupBox1.Controls.Add(this.NivelPWM);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(50, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 166);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleção de Dados";
            // 
            // Vcc
            // 
            this.Vcc.FormattingEnabled = true;
            this.Vcc.Items.AddRange(new object[] {
            "opcao1",
            "opcao2",
            "opcao3"});
            this.Vcc.Location = new System.Drawing.Point(275, 75);
            this.Vcc.Name = "Vcc";
            this.Vcc.Size = new System.Drawing.Size(100, 23);
            this.Vcc.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(275, 52);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 17);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Vref/Vcc:";
            // 
            // Frequency
            // 
            this.Frequency.FormattingEnabled = true;
            this.Frequency.Items.AddRange(new object[] {
            "valor1",
            "valor2",
            "valor3"});
            this.Frequency.Location = new System.Drawing.Point(150, 75);
            this.Frequency.Name = "Frequency";
            this.Frequency.Size = new System.Drawing.Size(100, 23);
            this.Frequency.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(150, 52);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 17);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Frequência:";
            // 
            // buttonAvancar
            // 
            this.buttonAvancar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAvancar.Location = new System.Drawing.Point(25, 119);
            this.buttonAvancar.Name = "buttonAvancar";
            this.buttonAvancar.Size = new System.Drawing.Size(350, 30);
            this.buttonAvancar.TabIndex = 3;
            this.buttonAvancar.Text = "Avançar";
            this.buttonAvancar.UseVisualStyleBackColor = true;
            this.buttonAvancar.Click += new System.EventHandler(this.next_Click);
            // 
            // NivelPWM
            // 
            this.NivelPWM.FormattingEnabled = true;
            this.NivelPWM.Items.AddRange(new object[] {
            "2 níveis",
            "3 níveis"});
            this.NivelPWM.Location = new System.Drawing.Point(25, 75);
            this.NivelPWM.Name = "NivelPWM";
            this.NivelPWM.Size = new System.Drawing.Size(100, 23);
            this.NivelPWM.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(25, 52);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 17);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Nível PWM:";
            // 
            // buttonLiga
            // 
            this.buttonLiga.BackColor = System.Drawing.Color.LightGreen;
            this.buttonLiga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLiga.Location = new System.Drawing.Point(25, 29);
            this.buttonLiga.Name = "buttonLiga";
            this.buttonLiga.Size = new System.Drawing.Size(100, 41);
            this.buttonLiga.TabIndex = 4;
            this.buttonLiga.Text = "Liga";
            this.buttonLiga.UseVisualStyleBackColor = false;
            this.buttonLiga.Click += new System.EventHandler(this.liga_Click);
            // 
            // buttonDesliga
            // 
            this.buttonDesliga.BackColor = System.Drawing.Color.Salmon;
            this.buttonDesliga.Enabled = false;
            this.buttonDesliga.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDesliga.Location = new System.Drawing.Point(150, 29);
            this.buttonDesliga.Name = "buttonDesliga";
            this.buttonDesliga.Size = new System.Drawing.Size(100, 41);
            this.buttonDesliga.TabIndex = 5;
            this.buttonDesliga.Text = "Desliga";
            this.buttonDesliga.UseVisualStyleBackColor = false;
            this.buttonDesliga.Click += new System.EventHandler(this.desliga_Click);
            // 
            // buttonAquisicao
            // 
            this.buttonAquisicao.Enabled = false;
            this.buttonAquisicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAquisicao.Location = new System.Drawing.Point(275, 29);
            this.buttonAquisicao.Name = "buttonAquisicao";
            this.buttonAquisicao.Size = new System.Drawing.Size(100, 41);
            this.buttonAquisicao.TabIndex = 6;
            this.buttonAquisicao.Text = "Aquisição";
            this.buttonAquisicao.UseVisualStyleBackColor = true;
            this.buttonAquisicao.Click += new System.EventHandler(this.aquisicao_Click);
            // 
            // buttonFinalizar
            // 
            this.buttonFinalizar.Enabled = false;
            this.buttonFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalizar.Location = new System.Drawing.Point(50, 418);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.Size = new System.Drawing.Size(400, 31);
            this.buttonFinalizar.TabIndex = 7;
            this.buttonFinalizar.Text = "Finalizar Experimento";
            this.buttonFinalizar.UseVisualStyleBackColor = true;
            this.buttonFinalizar.Click += new System.EventHandler(this.finalizar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonVoltar);
            this.groupBox2.Controls.Add(this.buttonDesliga);
            this.groupBox2.Controls.Add(this.buttonLiga);
            this.groupBox2.Controls.Add(this.buttonAquisicao);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(50, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 133);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Execução";
            // 
            // buttonVoltar
            // 
            this.buttonVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonVoltar.Location = new System.Drawing.Point(25, 87);
            this.buttonVoltar.Name = "buttonVoltar";
            this.buttonVoltar.Size = new System.Drawing.Size(350, 30);
            this.buttonVoltar.TabIndex = 6;
            this.buttonVoltar.Text = "Voltar a Seleção de Dados";
            this.buttonVoltar.UseVisualStyleBackColor = true;
            this.buttonVoltar.Click += new System.EventHandler(this.voltar_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "csv";
            this.saveFileDialog1.Filter = "Arquivos CSV|*.csv|Todos os arquivos|*.*";
            this.saveFileDialog1.Title = "Aquisição de Dados do Experimento";
            // 
            // Experimento2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 461);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonFinalizar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(titleE2);
            this.Name = "Experimento2";
            this.Text = "Experimento 2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox NivelPWM;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox Vcc;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox Frequency;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonAvancar;
        private System.Windows.Forms.Button buttonLiga;
        private System.Windows.Forms.Button buttonDesliga;
        private System.Windows.Forms.Button buttonAquisicao;
        private System.Windows.Forms.Button buttonFinalizar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}