using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace interfaceKitDidatico
{
    public partial class Experimento2 : Form
    {
        private PaginaInicial parent;
        public int tamanho_palavra;
        public Experimento2(PaginaInicial parent, int tamanho_palavra)
        {
            this.parent = parent;
            this.tamanho_palavra = tamanho_palavra;
            InitializeComponent();
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
                //Habilita "Execução" (botão "Liga" habilitado) e "Finalizar"
                groupBox2.Enabled = true;
                buttonFinalizar.Enabled = true;
                //Desabilita "Seleção de Dados"
                groupBox1.Enabled = false;
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

        }

        private void desliga_Click(object sender, EventArgs e)
        {
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
            //PaginaInicial.Enable = true;
            this.Close();
        }
    }
}
