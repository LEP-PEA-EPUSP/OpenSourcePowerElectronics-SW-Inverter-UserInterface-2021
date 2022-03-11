using System;
using System.IO;
using System.Windows.Forms;

namespace interfaceKitDidatico
{
    public partial class Experimento2 : Form
    {
        private PaginaInicial parent;
        public int tamanho_palavra;
        bool inversor = false;
        byte[] buffer = new byte[32];

        public Experimento2(PaginaInicial parent, int tamanho_palavra)
        {
            this.parent = parent;
            InitializeComponent();
            this.tamanho_palavra = tamanho_palavra;
        }

        private void next_Click(object sender, EventArgs e)
        {
            //Verifica se os dados não foram selecionados
            if (string.IsNullOrEmpty(NivelPWM.Text) || string.IsNullOrEmpty(Frequency.Text) || string.IsNullOrEmpty(Vcc.Text))
            {
                //Mensagem de erro caso usuário não tenha selecionado todos os dados
                MessageBox.Show("Erro: Selecione todos os dados necessários para o Experimento.");
            }
            else
            {
                //Habilita "Execução" (botão "Liga" habilitado)
                groupBox2.Enabled = true;
                //Desabilita "Seleção de Dados"
                groupBox1.Enabled = false;


                //Byte [5:1] - Request modulation update
                uint modUpdate = 0b_1000_0000;

                //Byte [5:2] - Número de níveis - {0: 2 níveis / 1: 3 níveis}
                if (NivelPWM.Text == "3 níveis")  modUpdate = 0b_1100_0000;

                //Byte [5:3-4] - Frequência - {00: 1200Hz / 01: 2400Hz / 10: 3600Hz / 11: 4600Hz}
                uint frequencia = Convert.ToUInt16(Frequency.Text);
                frequencia = (frequencia / 1200) - 1;
                frequencia = frequencia << 4;
                modUpdate = modUpdate | frequencia;

                //Byte [5:5-8] - Porcentagem Vref/Vcc 
                uint vref = Convert.ToUInt16(Vcc.Text);
                vref = vref / 10;
                modUpdate = modUpdate | vref;

                //Impressão no pacote
                buffer[5] = Convert.ToByte(modUpdate);
                Console.WriteLine(Convert.ToString(buffer[5], toBase: 2));
                //PaginaInicial.buffer[5] = buffer[5];
            }

        }

        private void voltar_Click(object sender, EventArgs e)
        {
            //Habilita "Seleção de Dados" e desabilita "Execução"
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        private void liga_Click(object sender, EventArgs e)
        {
            inversor = true;
            //Habilita botões "Desliga" e "Aquisição"
            buttonDesliga.Enabled = true;
            buttonAquisicao.Enabled = true;
            //Desabilita botões "Liga", "Voltar" e "Finalizar"
            buttonLiga.Enabled = false;
            buttonVoltar.Enabled = false;
            buttonFinalizar.Enabled = false;
        }

        private void aquisicao_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileInfo = new FileInfo(saveFileDialog1.FileName);
                string path = fileInfo.ToString();

                // seta variável que vai de 1 a 2024
                int n = 1;
                int m = 2024;
                string delimiter = "\t ";

                // Create a file to write to
                string createText = n.ToString() + delimiter + m.ToString() + Environment.NewLine;
                File.WriteAllText(path, createText);
                n++;
                m--;

                // Parte de loop que adiciona os outros número no arquivo
                while (n <= 2024)
                {
                    string appendText = n.ToString() + delimiter + m.ToString() + Environment.NewLine;
                    File.AppendAllText(path, appendText);
                    n++;
                    m--;
                }
            }
        }

        private void desliga_Click(object sender, EventArgs e)
        {
            inversor = false;
            //Habilita botões "Liga", "Voltar" e "Finalizar"
            buttonLiga.Enabled = true;
            buttonVoltar.Enabled = true;
            buttonFinalizar.Enabled = true;
            //Desabilita botões "Desliga" e "Aquisição"
            buttonDesliga.Enabled = false;
            buttonAquisicao.Enabled = false;

        }

        private void finalizar_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Enabled = true;
        }

        private void close_Click(object sender, FormClosingEventArgs e)
        {
            if (inversor == true)
            {
                MessageBox.Show("Erro: Desligue o inversor antes de fechar tela.");
                e.Cancel = true;
            }
            else
            {
                parent.Enabled = true;
            }
        }
    }
}
