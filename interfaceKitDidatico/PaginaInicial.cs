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
        /*Variáveis para pacotes de dados*/
        public static byte[] buffer = new byte[32]; //buffer de envio de dados
        public static byte[] buffer2 = new byte[10]; //buffer de recebimento de dados
        public static byte[] buffer3 = new byte[4101]; //buffer para aquisição de dados
        int tamanho_pacote_enviado = 32;
        int tamanho_pacote_recebido = 10;
        public static int answer_type; //Variáveis auxiliares para recebimento de dados

        /*Variáveis auxiliares de verificação e tratamento de erros*/
        int contador = 0; //Contagem do procedimento de comunicação
        bool aux_erro3 = false; //Auxiliar para erro de dados inconsistentes
        bool aux_erro4 = false; //Auxiliar para erro de desconexão da placa

        /*Inicialização da tela inicial*/
        public PaginaInicial()
        {
            InitializeComponent();
        }

    //[BLOCO 1 - COMUNICAÇÃO]//

        /* Função 1.1 - Seleção e abertuda da porta serial */
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Fecha porta serial se estiver aberta 
            if (serialPort1.IsOpen){
                serialPort1.Close();
            }

            //Determina porta COM usada, de acordo com a sxeleção do usuário
            serialPort1.PortName = comboBox_porta.Text;

            try 
            {
                serialPort1.Open(); //Abre porta serial
            }
            catch
            {
                ErrorHandler(1); // 1 --> Erro de escolha de porta serial não utilizada
            } 
        }

        /* Função 1.2 - Início da verificação de comunicação*/
        private void iniciarVerificacao_Click(object sender, EventArgs e)
        {
            textBox_status.Text = "Verificando"; //Atualiza texto de status da comunicação

            try
            {
                //Repete o procedimento de verificar comunicação até 3 vezes
                int retry = 0;
                while (retry < 3)
                {
                    comunicacao(); //Chama função de teste comunicação
                    retry++;

                    if (aux_erro3 == false) break; //Caso verificação não tiver erros, quebra repetição
                }
            }
            catch
            {
                ErrorHandler(2); // 2 --> Erro de escolha de porta serial errada
            }
            

            //Consolidação da verificação de comunicação 
            if (contador==10)
            {
                if (aux_erro3 == false)
                {
                    //Conjunto de ações realizadas após sucesso da verificação de comunicação
                    groupBox_comunicacao.Enabled = false;
                    textBox_status.Text = "Conectado";
                    textBox_status.BackColor = Color.LightGreen;
                    groupBox_experimento.Enabled = true;
                    timer1.Enabled = true;
                }
                else
                {
                    ErrorHandler(3); // 3 --> Erro de dados inconsistentes
                    aux_erro3 = false;
                }
                contador = 0;
            }
        }

        /* Função 1.3 - Teste de comunicação */
        public void comunicacao()
        {
            int i;
            aux_erro3 = false;

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

                Task.Delay(100);

                //Recebimento dos dados retribuidos pelo ARM
                serialPort1.Read(buffer2, 0, 10);

                //Confere se dados devolvidos estão consistentes
                for (j = 0; j < 10; j++)
                {
                    //Se algum dado for incosistente, indica o erro de dados
                    if (buffer2[j] != 4)
                    {
                        aux_erro3 = true;
                    }
                    else aux_erro3 = false;
                }
                contador++;
            }
        }

        /* Função 1.4 - Timer (Se repete durante todo uso do aplicativo após ser ativada) */
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Envio de dados para o ARM
            try
            {
                serialPort1.Write(buffer, 0, tamanho_pacote_enviado);
            }
            catch
            {
                ErrorHandler(4); // 4 --> Erro de desconexão da placa
            }

            //Delay para compensar descompasso entre envio e recebimento de dados
            Task.Delay(50);

            //Recebimento de dados devolvidos pelo ARM
            Array.Clear(buffer2, 0, buffer2.Length); //Limpa buffer que receberá dados
            try
            {
                serialPort1.Read(buffer2, 0, 10);
            }
            catch
            {
                //Espaço para implementar erro de leitura futuramente
            }

            //Espaço para desenvolver mais a parte de recebimento de dados futuramente
            answer_type = Convert.ToInt16(buffer2[0] >> 7);

        }

        /* Função 1.5 - Tratamento de erros */
        private void ErrorHandler(int error_type)
        {
            // 1 --> Erro de escolha de porta serial não utilizada
            if (error_type == 1)
            {
                MessageBox.Show("Confira se a placa está conectada ao computador, entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa.", "Erro: Seleção de uma porta serial que não está sendo utilizada");
            }
            // 2 --> Erro de escolha de porta serial errada
            else if (error_type == 2)
            {
                MessageBox.Show("As opções de solução são: \n \n 1.Confira se a placa está conectada ao computador e se você selecionou a porta COM certa. Entre no 'Gerenciado de Dispositivos' e veja em 'Portas (COM e LPT)' qual porta está sendo utilizada na comunicação com a placa (USB Serial Port). \n \n 2.Certifique-se de que o inversor está desligado. Pressione o botão preto (reset) da placa Discovery (microcontrolador). Caso tenha dúvidas, peça ajuda a um monitor ou ao professor.", "Erro: Falha ao estabelecer comunicação.");
                textBox_status.Text = "Erro";
                textBox_status.BackColor = Color.Salmon;
            }
            // 3 --> Erro de dados incosistentes
            else if (error_type == 3)
            {
                MessageBox.Show("Dados enviados pelo ARM estão inconsistentes. As opções de solução são: \n \n 1.Tente clicar em 'Iniciar comunicação' novamente. Caso não funionar, tente a opção abaixo. \n \n 2.Certifique-se de que o inversor está desligado. Pressione o botão preto (reset) da placa Discovery (microcontrolador). Caso tenha dúvidas, peça ajuda de um monitor ou do professor.", "Erro: Falha na comunicação");
                textBox_status.Text = "Erro";
                textBox_status.BackColor = Color.Salmon;
            }

            // 4 --> Erro de desconexão da placa
            else if (error_type == 4)
            {
                if (!aux_erro4)
                {
                    aux_erro4 = true;
                    DialogResult result = MessageBox.Show("ATENÇÃO: Se o INVERSOR estiver LIGADO, desligue-o imediatamente!!! Após isso siga os passos: \n \n 1.Conecte novamente a placa ao computador \n \n 2.Pressione o botão preto (reset) da placa Discovery (microcontrolador). Caso tenha dúvidas, peça ajuda de um monitor ou do professor. \n \n 3.Abra o aplicativo da IHM novamente, e siga o procedimento de conexão. \n \n \n Você conseguiu desligar o inversor?", "Erro: PORTA DESCONECTADA", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else if (result == DialogResult.No)
                    {
                        aux_erro4 = false;
                        result = 0;
                    }

                }
            }
        }

    //[BLOCO 2 - SELEÇÃO DE EXPERIMENTO]//


        /* Função 2.1 - Escolha da tela/experimento */
        private void escolhaExperimento(object sender, EventArgs e)
        {
            //Quando usuário selecionar algum experimento, botão de "Avançar" é desbloqueado
            if (comboBox_tela != null) button_avancar.Enabled = true;
            else button_avancar.Enabled = false;
        }


        /* Função 2.2 - Abertura da tela/experimento */
        private void next_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox_tela.Text) == false)
            {
                string tela_escolhida;
                tela_escolhida = comboBox_tela.Text; //Registra tela escolhida

                //Abertura de telas
                if (tela_escolhida == "Tela 1 - Conversor Monofásico")
                {
                    //Comandos para abrir a tela
                    Tela1 tela = new Tela1(this, tamanho_pacote_enviado);
                    tela.Show();

                    //Impede que mexa na tela de Pagina Inicial após abertura do experimento
                    Enabled = false;

                    tela_escolhida = "";
                }
                else if (tela_escolhida == "Tela 2 - Conversor Trifásico")
                {
                    //Comandos para abrir a tela
                    Tela2 tela = new Tela2(this, tamanho_pacote_enviado);
                    tela.Show();

                    //Impede que mexa na tela de Pagina Inicial após abertura do experimento
                    Enabled = false;

                    tela_escolhida = "";
                }
                else if (tela_escolhida == "Tela 3 - Duty Cycle Fixo")
                {
                    //Comandos para abrir a tela
                    Tela3 tela = new Tela3(this, tamanho_pacote_enviado);
                    tela.Show();

                    //Impede que mexa na tela de Pagina Inicial após abertura do experimento
                    Enabled = false;

                    tela_escolhida = "";
                }
            }
        }
    }
}
