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
    public partial class gerarArquivoCSV : Form
    {
        string nomeArquivo;
        
        public gerarArquivoCSV()
        {
            InitializeComponent();
        }

        private void gerarCSV(object sender, EventArgs e)
        {
            //seta variável que vai de 1 a 2024
            int n = 1;
            // Seta o caminho e variável de nome do arquivo "path", o nome do arquivo sento Testinho.csv nesse exemplo
            // Muda-se "rebec" para seu nome de Usuário
            string path = @"C:\Users\rebec\Projetos\Teste CSV\Teste.csv";

            //Parte para separar as colunas (se tivesse)
            // Set the variable "delimiter" to ", ".
            //string delimiter = ", ";

            // Criação do arquivo e escrita da primeira linha
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = n.ToString() + Environment.NewLine;
                File.WriteAllText(path, createText);
                n++;
            }

            // Parte de loop que adiciona os outros número no arquivo
            while (n <= 2024)
            {
                string appendText = n.ToString() + Environment.NewLine;
                File.AppendAllText(path, appendText);
                n++;
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }
    }
}
