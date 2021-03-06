using System;
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
        int tamanho_pacote_enviado = 32;
        int tamanho_pacote_recebido = 10;
        int numeroExp = 0;
        bool alerta_aberto = false;
        public static byte[] buffer = new byte[32];
        public static byte[] buffer2 = new byte[10];
        bool erro_dados = false;  

        public PaginaInicial()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write(buffer, 0, tamanho_pacote_enviado);
                //serialPort1.Read --> para caso de data request
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
                Experimento2 tela = new Experimento2(this, tamanho_pacote_recebido);
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
            //MessageBox.Show("Recebido");
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
            try
            {
                comunicacao();
            }
            catch
            {
                MessageBox.Show("Erro: Seleção da porta serial errada. Confira se a placa está conectada ao computador, entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa.");
                textBox9.Text = "Erro";
                textBox9.BackColor = Color.Salmon;
            }

            if (contador==10)
            {
                if (erro_dados == false)
                {
                    comboBox1.Enabled = false;
                    textBox9.Text = "Conectado";
                    textBox9.BackColor = Color.LightGreen;
                    comboBox2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Erro: Falha na comunicação. Dados enviados pelo ARM estão inconsistentes.");
                    textBox9.Text = "Erro";
                    textBox9.BackColor = Color.Salmon;
                }
            }
        }

        //Teste de Comunicacao
        public void comunicacao()
        {
            int i;
            //Repete procedimento de envio e recebimento 10 vezes
            for (i = 0; i <= 10; i++)
            {
                //Criação do pacote de teste que será enviado
                int j;
                for (j = 0; j < 32; j++)
                {
                    buffer[j] = 4;
                    Console.WriteLine(Convert.ToString(buffer[j], toBase: 10)); //linha para testes
                }
                //Envio do pacote de teste
                serialPort1.Write(buffer, 0, 32);

                //Recebimento dos dados retribuidos pelo ARM
                serialPort1.Read(buffer2, 0, tamanho_pacote_recebido);

                //Confere se dados devolvidos estão consistentes
                for (j = 0; j < 10; j++)
                {
                    Console.WriteLine(Convert.ToString(j)); //linha para testes
                    Console.WriteLine(Convert.ToString(buffer2[j], toBase: 10)); //linha para testes
                    if (i==10 && buffer2[j] != 4)
                    {
                        //MessageBox.Show("Erro: Falha na comunicação. Dados enviados pelo ARM estão inconsistentes.");
                        erro_dados = true;
                    }
                }
            }
            contador = 10;
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
