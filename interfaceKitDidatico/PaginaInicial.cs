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
       
        int contador=0; //contagem do procedimento de comunicação
        int tamanho_pacote_enviado = 32; 
        int tamanho_pacote_recebido = 10;
        string tela_escolhida;
        bool alerta_aberto = false; //auxiliar para erro de desconexão da placa
        public static byte[] buffer = new byte[32]; //buffer de envio de dados
        public static byte[] buffer2 = new byte[10]; //buffer de recebimento de dados
        public static byte[] buffer3 = new byte[4101]; //buffer para aquisição de dados
        bool erro_dados = false;

        //Variáveis auxiliares para recebimento de dados
        int answer_type;
        int no_exp;
        int status;
        int inverter_enable;
        int PWM_foundation_update;
        int PWM_counter_update;
        int DAC_update;

        public PaginaInicial()
        {
            InitializeComponent();
        }

        //Função timer - se repete durante todo uso do aplicativo
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Sistema try-catch para tratar erro de desconexão da placa
            try
            {
                serialPort1.Write(buffer, 0, tamanho_pacote_enviado);
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
                            MessageBox.Show("Erro: Não foi possível reconectar a placa. Tente novamente: Conecte novamente a placa e clique em 'OK'.");
                        }
                        alerta_aberto = false;
                        result = 0;
                    }
                }
            }

            //Recebimento de dados
            serialPort1.Read(buffer2, 0, tamanho_pacote_recebido);
            
            answer_type = Convert.ToInt16(buffer2[0]>>7);
            if (answer_type == 0)
            {
                no_exp = Convert.ToInt16((buffer2[0] & 01111000) >> 3);
                status = Convert.ToInt16(buffer2[0] & 00000111);

                inverter_enable = Convert.ToInt16(buffer2[1] >> 7);
                PWM_foundation_update = Convert.ToInt16((buffer2[1] & 01000000) >> 6);
                PWM_counter_update = Convert.ToInt16((buffer2[1] & 00100000) >> 5);
                DAC_update = Convert.ToInt16((buffer2[1] & 00010000) >> 4);

            }
            else if (answer_type == 1)
            {
                serialPort1.Read(buffer3, 0, 4101);
                //parte de aquisição
            }

        }

        private void serialPort1_ErrorReceived(object sender, System.IO.Ports.SerialErrorReceivedEventArgs e)
        {
      
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
        
        }

        //Função de conexão com a placa
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fecha porta serial se estiver aberta 
            if (serialPort1.IsOpen){
                serialPort1.Close();
            }

            //Determina qual porta COM será usada, de acordo com o que foi selecionado pelo usuário
            serialPort1.PortName = comboBox_porta.Text;

            //Sistema try-catch para tratar erro de seleção de uma porta que não está sendo usada
            try 
            {
                //Abre porta serial
                serialPort1.Open();
                
            }
            catch
            {
                //Tratamento de erro
                MessageBox.Show("Erro: Seleção de uma porta serial que não está sendo utilizada. Confira se a placa está conectada ao computador, entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa.");
            } 
        }

        //Função de início da verificação de comunicação
        private void iniciarVerificacao_Click(object sender, EventArgs e)
        {
            textBox_status.Text = "Verificando";

            //Sistema try-catch para tratar erro de seleção de porta serial errada
            try
            {
                //Chama função de comunicação
                comunicacao();
            }
            catch
            {
                //Tratamento de erro
                MessageBox.Show("Erro: Seleção da porta serial errada. Confira se a placa está conectada ao computador, entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa.");
                textBox_status.Text = "Erro";
                textBox_status.BackColor = Color.Salmon;
            }

            //Consolidação da verificação de comunicação 
            if (contador==10)
            {
                if (erro_dados == false)
                {
                    //Conjunto de ações quando comunicação deu certo
                    groupBox_comunicacao.Enabled = false;
                    textBox_status.Text = "Conectado";
                    textBox_status.BackColor = Color.LightGreen;
                    groupBox2.Enabled = true;
                }
                else
                {
                    //Tratamento de erro
                    MessageBox.Show("Erro: Falha na comunicação. Dados enviados pelo ARM estão inconsistentes.");
                    textBox_status.Text = "Erro";
                    textBox_status.BackColor = Color.Salmon;
                }
            }
        }

        //Teste de Comunicacao
        public void comunicacao()
        {
            erro_dados = false;
            int i;
            //Repete procedimento de envio e recebimento 10 vezes
            for (i = 0; i <= 10; i++)
            {
                //Criação do pacote de teste que será enviado
                int j;
                for (j = 0; j < 32; j++)
                {
                    buffer[j] = 4;
                    //Console.WriteLine(Convert.ToString(buffer[j], toBase: 10)); //linha para testes
                }
                //Envio do pacote de teste
                serialPort1.Write(buffer, 0, 32);

                Task.Delay(10);

                //Recebimento dos dados retribuidos pelo ARM
                serialPort1.Read(buffer2, 0, 10);

                //Confere se dados devolvidos estão consistentes
                for (j = 0; j < 10; j++)
                {
                    //Console.WriteLine(Convert.ToString(j)); //linha para testes
                    Console.WriteLine(Convert.ToString(buffer2[j], toBase: 10)); //linha para testes

                    //Se algum dado for incosistente, indica o erro de dados
                    if (buffer2[j] != 4)
                    {
                        erro_dados = true;
                    }
                }
            }
            //Ao sair do ciclo do for, contador vai a 10
            contador = 10;
        }

        //Função para escolha do experimento
        private void escolhaExperimento(object sender, EventArgs e)
        {
            //Qunaod usuário selecionar algum experimento, botão de "Avançar" é desbloqueado
            if (comboBox_tela != null) button_avancar.Enabled = true;
            else button_avancar.Enabled = false;

        }

        //Função de avanço para abertura do experimento
        private void next_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_tela.Text) == false)
            {
                //Registra tela escolhida
                tela_escolhida = comboBox_tela.Text; 
                //Função timer é ligada
                timer1.Enabled = true;

                //Abertura de telas
                if (tela_escolhida == "Tela 1 - Conversor monofásico")
                {
                    //Comandos para abrir a tela
                    Tela1 tela = new Tela1(this, tamanho_pacote_enviado);
                    tela.Show();

                    //Impede que mexa na tela de Pagina Inicial após abertura do experimento
                    Enabled = false;

                    tela_escolhida = "";
                }
                else if (tela_escolhida == "Tela 2 - Conversor trifásico")
                {
                    //Comandos para abrir a tela
                    Tela2 tela = new Tela2(this, tamanho_pacote_enviado);
                    tela.Show();

                    //Impede que mexa na tela de Pagina Inicial após abertura do experimento
                    Enabled = false;

                    tela_escolhida = "";
                }

            }

        }


    }
}
