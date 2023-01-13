namespace interfaceKitDidatico
{
    partial class Tela2
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
            System.Windows.Forms.TextBox titulo_T2;
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.IndiceMod = new System.Windows.Forms.ComboBox();
            this.PulsosCiclo = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.FrequenciaMod = new System.Windows.Forms.ComboBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonAvancar = new System.Windows.Forms.Button();
            this.SequenceZero = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonVoltar = new System.Windows.Forms.Button();
            this.buttonDesliga = new System.Windows.Forms.Button();
            this.buttonLiga = new System.Windows.Forms.Button();
            this.buttonAquisicao = new System.Windows.Forms.Button();
            this.buttonFinalizar = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            titulo_T2 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titulo_T2
            // 
            titulo_T2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            titulo_T2.BackColor = System.Drawing.SystemColors.MenuBar;
            titulo_T2.CausesValidation = false;
            titulo_T2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            titulo_T2.Location = new System.Drawing.Point(50, 26);
            titulo_T2.Name = "titulo_T2";
            titulo_T2.ReadOnly = true;
            titulo_T2.Size = new System.Drawing.Size(400, 29);
            titulo_T2.TabIndex = 2;
            titulo_T2.TabStop = false;
            titulo_T2.Text = "Tela 2 - Conversor Trifásico";
            titulo_T2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.IndiceMod);
            this.groupBox1.Controls.Add(this.PulsosCiclo);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.FrequenciaMod);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.buttonAvancar);
            this.groupBox1.Controls.Add(this.SequenceZero);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(50, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 205);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleção de Dados";
            // 
            // IndiceMod
            // 
            this.IndiceMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.IndiceMod.FormattingEnabled = true;
            this.IndiceMod.Items.AddRange(new object[] {
            "0",
            "25",
            "50",
            "75",
            "100",
            "115",
            "130",
            "150"});
            this.IndiceMod.Location = new System.Drawing.Point(202, 50);
            this.IndiceMod.Name = "IndiceMod";
            this.IndiceMod.Size = new System.Drawing.Size(155, 23);
            this.IndiceMod.TabIndex = 8;
            // 
            // PulsosCiclo
            // 
            this.PulsosCiclo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PulsosCiclo.FormattingEnabled = true;
            this.PulsosCiclo.Items.AddRange(new object[] {
            "10",
            "20",
            "30",
            "40",
            "50"});
            this.PulsosCiclo.Location = new System.Drawing.Point(202, 120);
            this.PulsosCiclo.Name = "PulsosCiclo";
            this.PulsosCiclo.Size = new System.Drawing.Size(155, 23);
            this.PulsosCiclo.TabIndex = 7;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(202, 84);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(155, 35);
            this.textBox4.TabIndex = 6;
            this.textBox4.Text = "Pulsos de chaveamento por ciclo:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(202, 30);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(155, 21);
            this.textBox3.TabIndex = 4;
            this.textBox3.Text = "Índice de modulação (%):";
            // 
            // FrequenciaMod
            // 
            this.FrequenciaMod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FrequenciaMod.FormattingEnabled = true;
            this.FrequenciaMod.Items.AddRange(new object[] {
            "30",
            "60"});
            this.FrequenciaMod.Location = new System.Drawing.Point(44, 120);
            this.FrequenciaMod.Name = "FrequenciaMod";
            this.FrequenciaMod.Size = new System.Drawing.Size(141, 23);
            this.FrequenciaMod.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(44, 84);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(141, 35);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Frequência da moduladora (Hz):";
            // 
            // buttonAvancar
            // 
            this.buttonAvancar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAvancar.Location = new System.Drawing.Point(19, 159);
            this.buttonAvancar.Name = "buttonAvancar";
            this.buttonAvancar.Size = new System.Drawing.Size(356, 30);
            this.buttonAvancar.TabIndex = 3;
            this.buttonAvancar.Text = "Avançar";
            this.buttonAvancar.UseVisualStyleBackColor = true;
            this.buttonAvancar.Click += new System.EventHandler(this.next_Click);
            // 
            // SequenceZero
            // 
            this.SequenceZero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SequenceZero.FormattingEnabled = true;
            this.SequenceZero.Items.AddRange(new object[] {
            "Desligada",
            "Ligada"});
            this.SequenceZero.Location = new System.Drawing.Point(44, 50);
            this.SequenceZero.Name = "SequenceZero";
            this.SequenceZero.Size = new System.Drawing.Size(141, 23);
            this.SequenceZero.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(44, 30);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 15);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Injeção da sequência 0:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonVoltar);
            this.groupBox2.Controls.Add(this.buttonDesliga);
            this.groupBox2.Controls.Add(this.buttonLiga);
            this.groupBox2.Controls.Add(this.buttonAquisicao);
            this.groupBox2.Enabled = false;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(50, 282);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 133);
            this.groupBox2.TabIndex = 9;
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
            this.buttonFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFinalizar.Location = new System.Drawing.Point(50, 438);
            this.buttonFinalizar.Name = "buttonFinalizar";
            this.buttonFinalizar.Size = new System.Drawing.Size(400, 31);
            this.buttonFinalizar.TabIndex = 10;
            this.buttonFinalizar.Text = "Finalizar Experimento";
            this.buttonFinalizar.UseVisualStyleBackColor = true;
            this.buttonFinalizar.Click += new System.EventHandler(this.finalizar_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.DefaultExt = "txt";
            this.saveFileDialog1.Filter = "Arquivos TXT|*.txt|Todos os arquivos|*.*";
            this.saveFileDialog1.Title = "Aquisição de Dados do Experimento";
            // 
            // Tela2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 501);
            this.Controls.Add(this.buttonFinalizar);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(titulo_T2);
            this.Name = "Tela2";
            this.Text = "Tela 2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox PulsosCiclo;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox FrequenciaMod;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button buttonAvancar;
        private System.Windows.Forms.ComboBox SequenceZero;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonVoltar;
        private System.Windows.Forms.Button buttonDesliga;
        private System.Windows.Forms.Button buttonLiga;
        private System.Windows.Forms.Button buttonAquisicao;
        private System.Windows.Forms.Button buttonFinalizar;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ComboBox IndiceMod;
    }
}