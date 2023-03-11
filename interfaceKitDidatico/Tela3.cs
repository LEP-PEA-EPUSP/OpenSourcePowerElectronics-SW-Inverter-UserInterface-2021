// [TELA 2 - DUTY CYCLE FIXO]

/*Bibliotecas*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

/*Inicialização do aplicativo*/
namespace interfaceKitDidatico
{
    /*Definição da Tela 3*/
    public partial class Tela3 : Form
    {
        /*Variáveis gerais*/
        private TelaInicial parent;
        public int tamanho_palavra;
        bool inversor = false;

        //Variáveis auxiliares --> Objetivo: Saber se o usuário mudou ou não as entradas do experimento
        string auxNivelPWM = null;
        string auxDutyCycle = null;
        string auxFrequenciaMod = null;


        //Variáveis para a montagem do pacote
        byte[] buffer = new byte[32];
        byte[] buffer2 = new byte[10];
        uint Byte1;
        uint Byte2;
        uint Byte3;
        uint Byte4;
        uint Byte5;
        uint Byte6;
        uint Byte7;
        uint Byte8;

        //Variáveis de resposta
        int answer_type;
        int answer_no_Program;
        int answer_status;
        int answer_inverterEnable;
        int answer_pwmFoundationUpdate;
        int answer_pwmCounterUpdate;
        int answer_dacUpdate;

        //Inicialização da Tela 3
        public Tela3(TelaInicial parent, int tamanho_palavra)
        {
            this.parent = parent;
            InitializeComponent();
            this.tamanho_palavra = tamanho_palavra;
        }

    //[TELA 3 (EXPERIMENTO) - BLOCO 1 - PACOTE DE DADOS]//

        /* Função 1.1 - Seleção de parâmetros */
        private void next_Click(object sender, EventArgs e)
        {
            //Verifica se os dados não foram selecionados
            if (string.IsNullOrEmpty(DutyCycle.Text) || string.IsNullOrEmpty(FrequenciaMod.Text))
            {
                //Mensagem de erro caso usuário não tenha selecionado todos os dados
                MessageBox.Show("Erro: Selecione todos os dados necessários para o Experimento.");
            }
            else if (Convert.ToDouble(DutyCycle.Text) < 0 || Convert.ToDouble(DutyCycle.Text) > 100)
            {
                //Mensagem de erro caso usuário não tenha selecionado todos os dados
                MessageBox.Show("Erro: Insira um valor de 0 a 100 (%) para o Duty Cycle.");
            }
            else
            {
                PacketAssemble_T3();

                //Intertravamento do botões
                groupBox2.Enabled = true; //Habilita "Execução" (botão "Liga" habilitado)
                groupBox1.Enabled = false; //Desabilita "Seleção de Dados"

                buffer2 = TelaInicial.buffer2;
                //Console.WriteLine("Pacote recebido:");
                //Console.WriteLine(Convert.ToString(buffer2[0], toBase: 2));
                //Console.WriteLine(Convert.ToString(buffer2[1], toBase: 2));


                answer_type = Convert.ToInt16(buffer2[0] >> 7);
                answer_no_Program = Convert.ToInt16((buffer2[0] & 01111000) >> 3);
                answer_status = Convert.ToInt16(buffer2[0] & 00000111);
                answer_inverterEnable = Convert.ToInt16(buffer2[1] >> 7);
                answer_pwmFoundationUpdate = Convert.ToInt16((buffer2[1] & 01000000) >> 6);
                answer_pwmCounterUpdate = Convert.ToInt16((buffer2[1] & 00100000) >> 5);
                answer_dacUpdate = Convert.ToInt16((buffer2[1] & 00010000) >> 4);

            }

        }

        /* Função 1.2 - Atualização dos pacotes de dados */
        private void PacketAssemble_T3()
        {
            //----------Definições Byte [1]----------//

            //Byte [1:1] - Packet type (0: Command / 1: Data request)
            Byte1 = 0b_0000_0000;

            //Byte [1:2-5] - Program Number
            uint no_Program = 1;
            Byte1 = Byte1 | (no_Program << 1);

            //Byte [1:6-8] - Subparte do experimento
            uint InternalSubset = 3;
            Byte1 = Byte1 | (InternalSubset << 5);

            //----------Definições Byte [2]----------//

            //Byte [2:1] - Inversor enable pin
            Byte2 = 0b_0000_0000;

            //Byte [2:2] - Request foundation update (0: não houve mudança no parâmetro | 1: houve mudnaça)
            if (auxNivelPWM == null)
            {
                Byte2 = Byte2 | (1 << 1);
            }
            else Byte2 = Byte2 | (0 << 1);

            //Byte [2:3-6] - Polarity (Ch1=Ch2=Ch3=Ch4=1)
            Byte2 = Byte2 | (1 << 2);
            Byte2 = Byte2 | (1 << 3);
            Byte2 = Byte2 | (1 << 4);
            Byte2 = Byte2 | (1 << 5);

            //Byte [2:7] - Repetition counter (Single update --> 1 | double update --> 0)
            //Não se aplica

            //Byte [2:8] - Request PWM counter configuration update (0: não houve mudança no parâmetro | 1: houve mudnaça) 
            if (auxNivelPWM == null)
            {
                Byte2 = Byte2 | (1 << 1);
            }
            else Byte2 = Byte2 | (0 << 1);

            //----------Definições Byte [3]: ARR (high)----------//

            Byte3 = 0b_0000_0000; //Não se aplica


            //----------Definições Byte [4]: ARR (low)----------//

            Byte4 = 0b_0000_0000; //Não se aplica

            //----------Definições Byte [5]----------//

            //Byte [5:1-4] - PWM prescaler value (PSC)
            Byte5 = 0b_0000_0000; //Não se aplica

            //Byte [5:5-8] - PWM clock divider (TIM1)
            //Não se aplica

            //----------Definições Byte [6]----------//

            Byte6 = 0b_0000_0000;
            //Byte [6:1] - Request DAC update
            //Byte [6:2] - DAC enable
            //Byte [6:3-5] - DAC output 1 config
            //Byte [6:6-8] - DAC output 2 config (future usage)

            //----------Definições Byte [7]----------//

            //Byte [7:1] - Request modulation update ***
            Byte7 = 0b_0000_0000;
            if (auxDutyCycle != DutyCycle.Text || auxFrequenciaMod != FrequenciaMod.Text)
            {
                Byte7 = Byte7 | 1;
            }

            //Byte [7:2-8] - Frequência da moduladora - {30 ou 60 Hz}
            uint valorFrequencia = 0;
            valorFrequencia = Convert.ToUInt16(FrequenciaMod.Text);
            valorFrequencia = valorFrequencia / 1000;
            Byte7 = Byte7 | (valorFrequencia << 1);


            //----------Definições Byte [8]----------//

            //Byte [8:1-7] - Parte inteira Duty Cycle
            //Byte [8:8] - Parte decimal Duty Cycle (0 -> .0 // 1 -> .5)

            double valorDutyCycle = Convert.ToDouble(DutyCycle.Text);

            double parteDecimal;
            uint parteInteiraDutyCycle = 0;
            uint indicadorDecimalDutyCycle = 0;

            parteDecimal = (valorDutyCycle - Math.Truncate(valorDutyCycle)) * 10;
            if (parteDecimal < 5)
            {
                parteInteiraDutyCycle = Convert.ToUInt16(Math.Truncate(valorDutyCycle));
                indicadorDecimalDutyCycle = 0;
            }
            else if (parteDecimal == 5)
            {
                parteInteiraDutyCycle = Convert.ToUInt16(Math.Truncate(valorDutyCycle));
                indicadorDecimalDutyCycle = 1;
            }
            else if (parteDecimal > 5)
            {
                parteInteiraDutyCycle = Convert.ToUInt16(Math.Truncate(valorDutyCycle) + 1);
                indicadorDecimalDutyCycle = 0;
            }


            Console.WriteLine(Convert.ToString(valorDutyCycle));
            Console.WriteLine(Convert.ToString(parteInteiraDutyCycle));
            Console.WriteLine(Convert.ToString(indicadorDecimalDutyCycle));

            Byte8 = 0b_0000_0000;
            Byte8 = Byte8 | (parteInteiraDutyCycle);
            Byte8 = Byte8 | (indicadorDecimalDutyCycle << 7);


            //----------Registro dos bytes no pacote----------//

            buffer[0] = Convert.ToByte(Byte1);
            buffer[1] = Convert.ToByte(Byte2);
            buffer[2] = Convert.ToByte(Byte3);
            buffer[3] = Convert.ToByte(Byte4);
            buffer[4] = Convert.ToByte(Byte5);
            buffer[5] = Convert.ToByte(Byte6);
            buffer[6] = Convert.ToByte(Byte7);
            buffer[7] = Convert.ToByte(Byte8);

            //----------Linhas para testes----------//
            //Console.WriteLine("Pacote enviado:");
            //Console.WriteLine(Convert.ToString(buffer[0], toBase: 2));
            //Console.WriteLine(Convert.ToString(buffer[1], toBase: 2));
            //Console.WriteLine(Convert.ToString(buffer[2], toBase: 2));
            //Console.WriteLine(Convert.ToString(buffer[3], toBase: 2));
            //Console.WriteLine(Convert.ToString(buffer[4], toBase: 2));
            //Console.WriteLine(Convert.ToString(buffer[5], toBase: 2));
            //Console.WriteLine(Convert.ToString(buffer[6], toBase: 2));
            //Console.WriteLine(Convert.ToString(buffer[7], toBase: 2));

            //----------Envio do buffer para Pagina Inicial----------//
            TelaInicial.buffer = buffer;

            //Registro de parâmetros
            auxDutyCycle = DutyCycle.Text;
            auxFrequenciaMod = FrequenciaMod.Text;
            auxNivelPWM = "1";
        }

    //[TELA 3 (EXPERIMENTO) - BLOCO 2 - EXECUÇÃO]//

        /* Função 2.1 -  Volta a seleção de dados*/
        private void voltar_Click(object sender, EventArgs e)
        {
            //Habilita "Seleção de Dados" e desabilita "Execução"
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
        }

        /* Função 2.2 -  Liga o inversor*/
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

            //-----Atualização de informações do pacote: Liga Inversor-----//

            // Byte [2:1] - Inversor enable pin (ligado)
            Byte2 = Byte2 | 1;

            //Byte [2:2] - Request foundation update
            Byte2 = Byte2 | (0 << 1);

            //Byte [2:8] - Request PWM counter configuration update
            Byte2 = Byte2 | (0 << 7);

            //Byte [7:1] - Request modulation update
            Byte7 = Byte7 | 0;

            //----------Registro dos bytes no pacote----------//
            buffer[1] = Convert.ToByte(Byte2);
            buffer[6] = Convert.ToByte(Byte7);

            //Console.WriteLine(Convert.ToString(buffer[2], toBase: 2)); //linha para testes
            //Console.WriteLine(Convert.ToString(buffer[7], toBase: 2)); //linha para testes

            TelaInicial.buffer[1] = buffer[1];
            TelaInicial.buffer[6] = buffer[6];
        }

        /* Função 2.3 -  Aquisição de dados*/
        private void aquisicao_Click(object sender, EventArgs e)
        {
            //-----Atualização de informações do pacote: Pede aquisição-----//

            //Byte [1:1] - Packet type (0: Command / 1: Data request)
            Byte1 = Byte1 | 1;

            buffer[0] = Convert.ToByte(Byte1);
            //Console.WriteLine(Convert.ToString(buffer[1], toBase: 2)); //linha para testes
            TelaInicial.buffer[0] = buffer[0];

            //Quando o pacote for do tipo data request, termos que adequar o tamanho do pacote

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

        /* Função 2.4 - Desliga o inversor*/
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

            //-----Atualização de informações do pacote: Desliga Inversor-----//

            // Byte [2:1] - Inversor enable pin (desligado)
            Byte2 = Byte2 & 0b_1111_1110;

            buffer[1] = Convert.ToByte(Byte2);

            TelaInicial.buffer[1] = buffer[1];

        }

        /* Função 2.5 - Finaliza o experimento*/
        private void finalizar_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Enabled = true;
            // É importante limpar o byte antes de fechar tela?
        }

        /* Função 2.6 - Fecha o experimento*/
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
