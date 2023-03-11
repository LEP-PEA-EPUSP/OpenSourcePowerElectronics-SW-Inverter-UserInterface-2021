namespace interfaceKitDidatico
{
    partial class TelaInicial
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TextBox textBox_titulo;
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox_porta = new System.Windows.Forms.ComboBox();
            this.button_iniciar = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox_tela = new System.Windows.Forms.ComboBox();
            this.textBox_status = new System.Windows.Forms.TextBox();
            this.button_avancar = new System.Windows.Forms.Button();
            this.groupBox_comunicacao = new System.Windows.Forms.GroupBox();
            this.groupBox_experimento = new System.Windows.Forms.GroupBox();
            textBox_titulo = new System.Windows.Forms.TextBox();
            this.groupBox_comunicacao.SuspendLayout();
            this.groupBox_experimento.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox_titulo
            // 
            textBox_titulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            textBox_titulo.BackColor = System.Drawing.SystemColors.MenuBar;
            textBox_titulo.CausesValidation = false;
            textBox_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox_titulo.Location = new System.Drawing.Point(50, 50);
            textBox_titulo.Name = "textBox_titulo";
            textBox_titulo.ReadOnly = true;
            textBox_titulo.Size = new System.Drawing.Size(400, 29);
            textBox_titulo.TabIndex = 0;
            textBox_titulo.TabStop = false;
            textBox_titulo.Text = "LEP-PEA - Eletrônica de Potência";
            textBox_titulo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.Parity = System.IO.Ports.Parity.Odd;
            this.serialPort1.PortName = "COM4";
            this.serialPort1.ReadTimeout = 500;
            this.serialPort1.WriteTimeout = 500;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(18, 54);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(117, 17);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Selecione Porta:";
            // 
            // comboBox_porta
            // 
            this.comboBox_porta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBox_porta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_porta.FormattingEnabled = true;
            this.comboBox_porta.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8",
            "COM9",
            "COM10",
            "COM11",
            "COM12",
            "COM13",
            "COM14",
            "COM15"});
            this.comboBox_porta.Location = new System.Drawing.Point(18, 74);
            this.comboBox_porta.Name = "comboBox_porta";
            this.comboBox_porta.Size = new System.Drawing.Size(117, 23);
            this.comboBox_porta.TabIndex = 2;
            this.comboBox_porta.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button_iniciar
            // 
            this.button_iniciar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_iniciar.Location = new System.Drawing.Point(150, 54);
            this.button_iniciar.Name = "button_iniciar";
            this.button_iniciar.Size = new System.Drawing.Size(103, 43);
            this.button_iniciar.TabIndex = 6;
            this.button_iniciar.Text = "Iniciar Verificação";
            this.button_iniciar.UseVisualStyleBackColor = true;
            this.button_iniciar.Click += new System.EventHandler(this.iniciarVerificacao_Click);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(267, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(103, 17);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Status:";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.Location = new System.Drawing.Point(50, 36);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(163, 17);
            this.textBox3.TabIndex = 11;
            this.textBox3.Text = "Selecione Experimento:";
            // 
            // comboBox_tela
            // 
            this.comboBox_tela.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tela.FormattingEnabled = true;
            this.comboBox_tela.Items.AddRange(new object[] {
            "Tela 1 - Conversor Monofásico",
            "Tela 2 - Conversor Trifásico",
            "Tela 3 - Duty Cycle Fixo"});
            this.comboBox_tela.Location = new System.Drawing.Point(50, 56);
            this.comboBox_tela.Name = "comboBox_tela";
            this.comboBox_tela.Size = new System.Drawing.Size(163, 23);
            this.comboBox_tela.TabIndex = 12;
            this.comboBox_tela.SelectedIndexChanged += new System.EventHandler(this.escolhaExperimento);
            // 
            // textBox_status
            // 
            this.textBox_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_status.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox_status.Location = new System.Drawing.Point(267, 76);
            this.textBox_status.Name = "textBox_status";
            this.textBox_status.Size = new System.Drawing.Size(117, 21);
            this.textBox_status.TabIndex = 10;
            // 
            // button_avancar
            // 
            this.button_avancar.Enabled = false;
            this.button_avancar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_avancar.Location = new System.Drawing.Point(239, 36);
            this.button_avancar.Name = "button_avancar";
            this.button_avancar.Size = new System.Drawing.Size(113, 43);
            this.button_avancar.TabIndex = 13;
            this.button_avancar.Text = "Avançar";
            this.button_avancar.UseVisualStyleBackColor = true;
            this.button_avancar.Click += new System.EventHandler(this.next_Click);
            // 
            // groupBox_comunicacao
            // 
            this.groupBox_comunicacao.AutoSize = true;
            this.groupBox_comunicacao.Controls.Add(this.textBox1);
            this.groupBox_comunicacao.Controls.Add(this.comboBox_porta);
            this.groupBox_comunicacao.Controls.Add(this.textBox2);
            this.groupBox_comunicacao.Controls.Add(this.textBox_status);
            this.groupBox_comunicacao.Controls.Add(this.button_iniciar);
            this.groupBox_comunicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_comunicacao.Location = new System.Drawing.Point(50, 106);
            this.groupBox_comunicacao.Name = "groupBox_comunicacao";
            this.groupBox_comunicacao.Size = new System.Drawing.Size(400, 151);
            this.groupBox_comunicacao.TabIndex = 14;
            this.groupBox_comunicacao.TabStop = false;
            this.groupBox_comunicacao.Text = "Verificação de Comunicação";
            // 
            // groupBox_experimento
            // 
            this.groupBox_experimento.Controls.Add(this.textBox3);
            this.groupBox_experimento.Controls.Add(this.comboBox_tela);
            this.groupBox_experimento.Controls.Add(this.button_avancar);
            this.groupBox_experimento.Enabled = false;
            this.groupBox_experimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_experimento.Location = new System.Drawing.Point(50, 263);
            this.groupBox_experimento.Name = "groupBox_experimento";
            this.groupBox_experimento.Size = new System.Drawing.Size(400, 113);
            this.groupBox_experimento.TabIndex = 15;
            this.groupBox_experimento.TabStop = false;
            this.groupBox_experimento.Text = "Experimento";
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 501);
            this.Controls.Add(this.groupBox_experimento);
            this.Controls.Add(this.groupBox_comunicacao);
            this.Controls.Add(textBox_titulo);
            this.Name = "TelaInicial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tela Inicial";
            this.groupBox_comunicacao.ResumeLayout(false);
            this.groupBox_comunicacao.PerformLayout();
            this.groupBox_experimento.ResumeLayout(false);
            this.groupBox_experimento.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox_porta;
        private System.Windows.Forms.Button button_iniciar;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox_tela;
        private System.Windows.Forms.TextBox textBox_status;
        private System.Windows.Forms.Button button_avancar;
        private System.Windows.Forms.GroupBox groupBox_comunicacao;
        private System.Windows.Forms.GroupBox groupBox_experimento;
    }
}

