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
        //Variáveis para pacotes de dados
        public static byte[] buffer = new byte[32]; //buffer de envio de dados
        public static byte[] buffer2 = new byte[10]; //buffer de recebimento de dados
        public static byte[] buffer3 = new byte[4101]; //buffer para aquisição de dados
        int tamanho_pacote_enviado = 32;
        int tamanho_pacote_recebido = 10;

        //Variáveis auxiliares de verificação e tratamento de erros
        int contador = 0; //contagem do procedimento de comunicação
        bool alerta_aberto = false; //auxiliar para erro de desconexão da placa
        bool erro_dados = false;
        string tela_escolhida;

        //Variáveis auxiliares para recebimento de dados
        public static int answer_type;
        public static int no_exp;
        public static int status;
        public static int inverter_enable;
        public static int PWM_foundation_update;
        public static int PWM_counter_update;
        public static int DAC_update;

        public PaginaInicial()
        {
            InitializeComponent();
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

            try 
            {
                serialPort1.Open(); //Abre porta serial
            }
            catch
            {
                ErrorHandler(1); // 1 --> erro de escolha de porta serial não utilizada
            } 
        }

        //Função de início da verificação de comunicação
        private void iniciarVerificacao_Click(object sender, EventArgs e)
        {
            textBox_status.Text = "Verificando";
            try
            {
                comunicacao(); //Chama função de comunicação
            }
            catch
            {
                ErrorHandler(2); // 1 --> erro de escolha de porta serial errada
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
                    ErrorHandler(3); // 3 --> Dados incosistentes
                }
            }
        }



        //Função para escolha do experimento
        private void escolhaExperimento(object sender, EventArgs e)
        {
            //Qunado usuário selecionar algum experimento, botão de "Avançar" é desbloqueado
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

        //Função timer - se repete durante todo uso do aplicativo (quando ativada)
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                serialPort1.Write(buffer, 0, tamanho_pacote_enviado);
            }
            catch
            {
                ErrorHandler(4); // 4 --> erro de desconexão da placa
            }

            //Recebimento de dados
            serialPort1.Read(buffer2, 0, tamanho_pacote_recebido);

            answer_type = Convert.ToInt16(buffer2[0] >> 7);
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

        //Teste de Comunicacao
        public void comunicacao()
        {
            erro_dados = false;
            int i;
            //Repete procedimento de envio e recebimento 10 vezes
            for (i = 0; i < 10; i++)
            {
                //Criação do pacote de teste que será enviado
                int j;
                for (j = 0; j < 32; j++)
                {
                    buffer[j] = 4;
                }

                //Envio do pacote de teste
                serialPort1.Write(buffer, 0, 32);

                Task.Delay(50);

                //Recebimento dos dados retribuidos pelo ARM
                serialPort1.Read(buffer2, 0, 10);

                //Confere se dados devolvidos estão consistentes
                for (j = 0; j < 10; j++)
                {
                    //Se algum dado for incosistente, indica o erro de dados
                    if (buffer2[j] != 4)
                    {
                        erro_dados = true;
                    }
                }
                contador++;
            }
        }

        private void ErrorHandler(int error_type)
        {
            // 1 --> Erro de escolha de porta serial não utilizada
            if (error_type == 1)
            {
                MessageBox.Show("Erro: Seleção de uma porta serial que não está sendo utilizada. Confira se a placa está conectada ao computador, entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa.");
            }
            // 2 --> Erro de escolha de porta serial errada
            else if (error_type == 2)
            {
                MessageBox.Show("Erro: Seleção da porta serial errada. Confira se a placa está conectada ao computador, entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa.");
                textBox_status.Text = "Erro";
                textBox_status.BackColor = Color.Salmon;
            }
            // 3 --> Dados incosistentes
            else if (error_type == 3)
            {
                MessageBox.Show("Erro: Falha na comunicação. Dados enviados pelo ARM estão inconsistentes.");
                textBox_status.Text = "Erro";
                textBox_status.BackColor = Color.Salmon;
            }

            // 4 --> Erro de desconexão da placa
            else if (error_type == 4)
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
        }

    }
}
