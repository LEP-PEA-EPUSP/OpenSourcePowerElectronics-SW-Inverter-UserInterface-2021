using System;
using System.IO;
using System.Windows.Forms;

namespace interfaceKitDidatico
{
    public partial class Tela1 : Form
    {
        private PaginaInicial parent;
        public int tamanho_palavra;
        bool inversor = false;

        //Variáveis auxiliares --> Objetivo: Saber se o usuário mudou ou não as entradas do experimento
        string auxNivelPWM = "null";
        string auxFrequenciaMod = "null";
        string auxIndiceMod = "null";
        string auxPulsosCiclo = "null";


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

        //Matrizes com valores de
        uint[,] array30 = new uint[5, 4] { { 35000, 4, 2, 0 }, { 35000, 2, 2, 0 }, { 46666, 1, 2, 0 }, { 35000, 0, 2, 0 }, { 28000, 1, 2, 0 } };
        uint[,] array60 = new uint[5, 4] { { 35000, 2, 2, 0 }, { 35000, 1, 2, 0 }, { 23000, 1, 2, 0 }, { 17500, 1, 2, 0 }, { 14000, 1, 2, 0 } };

        //Variáveis de resposta
        int answer_type;
        int no_exp;
        int status;
        int inverter_enable;
        int PWM_foundation_update;
        int PWM_counter_update;
        int DAC_update;

        public Tela1(PaginaInicial parent, int tamanho_palavra)
        {
            this.parent = parent;
            InitializeComponent();
            this.tamanho_palavra = tamanho_palavra;
        }

        private void next_Click(object sender, EventArgs e)
        {
            //Verifica se os dados não foram selecionados
            if (string.IsNullOrEmpty(NivelPWM.Text) || string.IsNullOrEmpty(FrequenciaMod.Text) || string.IsNullOrEmpty(IndiceMod.Text) || string.IsNullOrEmpty(PulsosCiclo.Text))
            {
                //Mensagem de erro caso usuário não tenha selecionado todos os dados
                MessageBox.Show("Erro: Selecione todos os dados necessários para o Experimento.");
            }
            else
            {
                PacketAssemble();

                //Intertravamento do botões
                groupBox2.Enabled = true; //Habilita "Execução" (botão "Liga" habilitado)
                groupBox1.Enabled = false; //Desabilita "Seleção de Dados"

                buffer2 = PaginaInicial.buffer2;
                //Console.WriteLine("Pacote recebido:");
                //Console.WriteLine(Convert.ToString(buffer2[0], toBase: 2));
                //Console.WriteLine(Convert.ToString(buffer2[1], toBase: 2));


                answer_type = Convert.ToInt16(buffer2[0] >> 7);
                no_exp = Convert.ToInt16((buffer2[0] & 01111000) >> 3);
                status = Convert.ToInt16(buffer2[0] & 00000111);
                inverter_enable = Convert.ToInt16(buffer2[1] >> 7);
                PWM_foundation_update = Convert.ToInt16((buffer2[1] & 01000000) >> 6);
                PWM_counter_update = Convert.ToInt16((buffer2[1] & 00100000) >> 5);
                DAC_update = Convert.ToInt16((buffer2[1] & 00010000) >> 4);




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

            PaginaInicial.buffer[1] = buffer[1];
            PaginaInicial.buffer[6] = buffer[6];
        }

        private void aquisicao_Click(object sender, EventArgs e)
        {
            //-----Atualização de informações do pacote: Pede aquisição-----//

            //Byte [1:1] - Packet type (0: Command / 1: Data request)
            Byte1 = Byte1 | 1;

            buffer[0] = Convert.ToByte(Byte1);
            //Console.WriteLine(Convert.ToString(buffer[1], toBase: 2)); //linha para testes
            PaginaInicial.buffer[0] = buffer[0];

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
            
            PaginaInicial.buffer[1] = buffer[1];

        }

        private void finalizar_Click(object sender, EventArgs e)
        {
            this.Close();
            parent.Enabled = true;
            // É importante limpar o byte antes de fechar tela?
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

        private void PacketAssemble()
        {
            uint ARR = 0;
            uint PSC = 0;
            uint RCR = 0;
            uint CKD = 0;

            int auxPulsos = Convert.ToInt32(PulsosCiclo.Text);
            auxPulsos = (auxPulsos / 10) - 1;

            if (FrequenciaMod.Text == "30")
            {
                ARR = array30[auxPulsos, 0];
                PSC = array30[auxPulsos, 1];
                RCR = array30[auxPulsos, 2];
                CKD = array30[auxPulsos, 3];

            }
            else if (FrequenciaMod.Text == "60")
            {
                ARR = array60[auxPulsos, 0];
                PSC = array60[auxPulsos, 1];
                RCR = array60[auxPulsos, 2];
                CKD = array60[auxPulsos, 3];

            }

            //----------Definições Byte [1]----------//

            //Byte [1:1] - Packet type (0: Command / 1: Data request)
            Byte1 = 0b_0000_0000;

            //Byte [1:2-5] - Exp. number
            uint numeroExp = 2;
            Byte1 = Byte1 | (numeroExp << 1);

            //Byte [1:6-8] - Subparte do experimento
            //Não se aplica a esse experimento


            //----------Definições Byte [2]----------//

            //Byte [2:1] - Inversor enable pin
            Byte2 = 0b_0000_0000; //MUDAR ISSO DEPOIS

            //Byte [2:2] - Request foundation update (0: não houve mudança no parâmetro | 1: houve mudnaça)
            if (auxNivelPWM != NivelPWM.Text)
            {
                Byte2 = Byte2 | (1 << 1);
            }
            else Byte2 = Byte2 | (0 << 1);

            //Byte [2:3-6] - PWM Polarity (2 níveis --> Ch1=0 e Ch2=1 | 3 níveis --> Ch1=Ch2=0)
            if (NivelPWM.Text == "2 níveis")
            {
                uint Ch2 = 1;
                Ch2 = Ch2 << 2;
                Byte2 = Byte2 | Ch2;
            }

            //Byte [2:7] - Repetition counter (Single update --> 1 | double update --> 0)
            Byte2 = Byte2 | (RCR << 6);

            //Byte [2:8] - Request PWM counter configuration update (0: não houve mudança no parâmetro | 1: houve mudnaça) 
            uint PWMcountUpdate;
            if (auxFrequenciaMod != FrequenciaMod.Text || auxPulsosCiclo != PulsosCiclo.Text)
            {
                PWMcountUpdate = 1;
            }
            else PWMcountUpdate = 0;
            Byte2 = Byte2 | (PWMcountUpdate << 7);

            //----------Definições Byte [3]: ARR (high)----------//

            Byte3 = 0b_0000_0000;
            Byte3 = (ARR >> 8) & 255;


            //----------Definições Byte [4]: ARR (low)----------//

            Byte4 = 0b_0000_0000;
            Byte4 = ARR & 255;

            //----------Definições Byte [5]----------//

            //Byte [5:1-4] - PWM prescaler value (PSC)
            Byte5 = 0b_0000_0000;
            Byte5 = PSC;

            //Byte [5:5-8] - PWM clock divider (TIM1)
            Byte5 = Byte5 | (CKD << 4);

            //----------Definições Byte [6]----------//

            Byte6 = 0b_0000_0000;
            //Byte [6:1] - Request DAC update
            //Byte [6:2] - DAC enable
            //Byte [6:3-5] - DAC output 1 config
            //Byte [6:6-8] - DAC output 2 config (future usage)

            //----------Definições Byte [7]----------//

            //Byte [7:1] - Request modulation update ***
            Byte7 = 0b_0000_0000;
            if (auxIndiceMod != IndiceMod.Text)
            {
                Byte7 = Byte7 | 1;
            }

            //Byte [7:2] - Número de níveis - {0: 2 níveis / 1: 3 níveis}
            if (NivelPWM.Text == "3 níveis") Byte7 = Byte7 | (1 << 1);

            //Byte [7:3-8] - Frequência da moduladora - {30 ou 60 Hz}
            if (Convert.ToUInt16(FrequenciaMod.Text) == 30)
            {
                Byte7 = Byte7 | (30 << 2);
            }
            else Byte7 = Byte7 | (60 << 2);

            //----------Definições Byte [8]----------//

            //Byte [8:1-8] - Índice de modulação
            Byte8 = 0b_0000_0000;
            Byte8 = Convert.ToUInt16(IndiceMod.Text);

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
            Console.WriteLine("Pacote enviado:");
            Console.WriteLine(Convert.ToString(buffer[0], toBase: 2));
            Console.WriteLine(Convert.ToString(buffer[1], toBase: 2));
            Console.WriteLine(Convert.ToString(buffer[2], toBase: 2));
            Console.WriteLine(Convert.ToString(buffer[3], toBase: 2));
            Console.WriteLine(Convert.ToString(buffer[4], toBase: 2));
            Console.WriteLine(Convert.ToString(buffer[5], toBase: 2));
            Console.WriteLine(Convert.ToString(buffer[6], toBase: 2));
            Console.WriteLine(Convert.ToString(buffer[7], toBase: 2));

            //----------Envio do buffer para Pagina Inicial----------//
            PaginaInicial.buffer = buffer;

            //Registro de parâmetros
            auxNivelPWM = NivelPWM.Text;
            auxFrequenciaMod = FrequenciaMod.Text;
            auxIndiceMod = IndiceMod.Text;
            auxPulsosCiclo = PulsosCiclo.Text;
        }

    }
}
