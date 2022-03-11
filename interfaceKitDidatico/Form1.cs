﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace interfaceKitDidatico
{
    public partial class PaginaInicial : Form
    {
       
        int contador=0;
        int tamanho_palavra = 10;
        int numeroExp = 0;
        bool alerta_aberto = false;
        public static byte[] buffer = new byte[10];
        public PaginaInicial()
        {
            InitializeComponent();
            //serialPort1.Open();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //serialPort1.Write(buffer, 0, tamanho_palavra);
            try
            {
                serialPort1.Write(buffer, 0, tamanho_palavra);
            }
            catch
            {
                if (!alerta_aberto)
                {
                    alerta_aberto = true;
                    DialogResult result = MessageBox.Show("Erro: Porta desconectada. Conecte novamente a placa e clique em 'OK'.");
                   if (result == DialogResult.OK)
                    {
                        try
                        {
                            serialPort1.Open();
                        }
                        catch
                        {
                            MessageBox.Show("Erro: Não foi possível reconectar a placa. Tente novamente.");
                        }
                        alerta_aberto = false;
                        result = 0;
                    }
                }
            }

            //Abertura de experimento
            if (numeroExp == 1)
            {
                MessageBox.Show("Erro: Esse experimento ainda não existe");
                numeroExp = 0;
            }
            else if (numeroExp == 2)
            {
                Experimento2 tela = new Experimento2(this, tamanho_palavra);
                tela.Show();
                Enabled = false;
                numeroExp = 0;
            }
            else if (numeroExp == 3)
            {
                MessageBox.Show("Erro: Esse experimento ainda não existe");
                numeroExp = 0;
            }
            else if (numeroExp != 0)
            {
                MessageBox.Show("Erro: Selecione um experimento válido");
                numeroExp = 0;
            }
        }

        private void serialPort1_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen){
                serialPort1.Close();
            }

            serialPort1.PortName = comboBox1.Text;

            try 
            {
                serialPort1.Open();
                
            }
            catch
            {
                MessageBox.Show("Erro: Seleção de uma porta serial que não está sendo utilizada. Confira se a placa está conectada ao computador, entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa.");
            } 
        }

        private void iniciarVerificacao_Click(object sender, EventArgs e)
        {
            textBox9.Text = "Verificando";
            int i;
            for (i=0; i <= 10; i++)
            {
                try
                {
                    comunicacao();
                    //comboBox1.Enabled = false;
                }
                catch
                {
                    MessageBox.Show("Erro: Seleção da porta serial errada. Confira se a placa está conectada ao computador, entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa.");
                    textBox9.Text = "Erro";
                    textBox9.BackColor = Color.Salmon;
                    break;
                }
            }
            if (i > 10)
            {
                comboBox1.Enabled = false;
                textBox9.Text = "Conectado";
                textBox9.BackColor = Color.LightGreen;
                comboBox2.Enabled = true;
            }
        }

        //Teste de Comunicacao
        public void comunicacao()
        {
            //Envio de dados para teste
            int i;
            for (i = 0; i < tamanho_palavra; i++)
            {
                buffer[i] = 0x41;
            }

            serialPort1.Write(buffer, 0, tamanho_palavra);

            //Essa parte não é necessária -- Impressão dos valores do buffer na caixa de texto que está Invisible
            string[] texto = new string[tamanho_palavra];
            for (i = 0; i < tamanho_palavra; i++)
            {
                texto[i] = buffer[i].ToString();
            }
            textBox4.Text = texto[0] + texto[1] + texto[2] + texto[3] + texto[4] + texto[5] + texto[6] + texto[7] + texto[8];

            //Recebimento de dados para teste
            byte[] buffer2 = new byte[tamanho_palavra];
            serialPort1.Read(buffer2, 0, tamanho_palavra);

            //Essa parte não é necessária -- Impressão dos valores do buffer na caixa de texto que está Invisible
            string[] texto2 = new string[tamanho_palavra];
            for (i = 0; i < tamanho_palavra; i++)
            {
                texto2[i] = buffer[i].ToString();
            }
            textBox5.Text = texto2[0] + texto2[1] + texto2[2] + texto2[3] + texto2[4] + texto2[5] + texto2[6] + texto2[7] + texto2[8];

            //Essa parte não é necessária -- A repetição da verificação está sendo feita na chamada da função através do for
            //contador++;
            //textBox6.Text = contador.ToString();
            /*if (contador > tamanho_palavra)
            {
                textBox9.Text = "Conectado";
                textBox9.BackColor = Color.LightGreen;
                comboBox2.Enabled = true;
                contador = 0;
            }*/
        }

        private void PaginaInicial_Load(object sender, EventArgs e)
        {

        }

        private void escolhaExperimento(object sender, EventArgs e)
        {
            if (comboBox2 != null) button1.Enabled = true;
            else button1.Enabled = false;
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox2.Text) == false)
            {
                numeroExp = Convert.ToInt32(comboBox2.Text);
                timer1.Enabled = true;
            }
        }
    }
}
