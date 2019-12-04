using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LeituraArquivoCsv
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Criando um DataTable
            DataTable dt = new DataTable();

            //Depois de montado o datatable, vamos falar para o grid
            //que a fonte de dados para ele exibir, será o datatable que 
            //a gente acabou de criar
            dataGridView1.DataSource = dt;

            //Marca o diretório a ser listado
            DirectoryInfo diretorio = new DirectoryInfo(@"C:\");

            //Executa função GetFile(Lista os arquivos desejados de acordo com o parametro)
            //FileInfo[] arquivos = diretorio.GetFiles("*.csv*");
            string[] arquivos = Directory.GetFiles(@"C:\" , "*.csv");

            string tempo = "";
            //Começamos a listar os arquivos
            foreach (string fileinfo in arquivos)
            {
                string[] lista = File.ReadAllLines(fileinfo);
                for (int i = 0; i < lista.Length; i++)
                {
                    if (i == 0)
                        continue;
                    tempo += lista[i] + "\n";
                }
                //Response.Write(fileinfo.Name);
            }

            //Lendo Todas as linhas do arquivo CSV
            
            string[] Linha = System.IO.File.ReadAllLines(@"C:\\ ");
            File.WriteAllText("Arquivos.csv", tempo);
            //Neste For, vamos percorrer todas as linhas que foram lidas do arquivo CSV
            for (Int32 i = 0; i < Linha.Length; i++)
            {
                //Aqui Estamos pegando a linha atual, e separando os campos
                //Por exemplo, ele vai lendo um texto, e quando achar um ponto e virgula
                //ele pega o texto e joga na outra posição do array temp, e assim por diante
                //até chegar no final da linha
                string[] campos = Linha[i].Split(Convert.ToChar(";"));

                //Um datable precisa de colunas
                //Como a função acima jogou cada campo em uma posição do array de acordo com
                //o ponto e virgula, eu estou pegando quantos campos ele achou e criando a mesma
                //quantidade de colunas no datatable para corresponder a cada campo
                if (i == 0)
                {
                    for (Int32 i2 = 0; i2 < campos.Length; i2++)
                    {
                        //Criando uma coluna
                        DataColumn col = new DataColumn();
                        //Adicionando a coluna criada ao datatable
                        dt.Columns.Add(col);
                    }
                }

                //Inserindo uma linha(row) no datable (Vai fazer isso para cada linha encontrada
                //no arquivo CSV
                dt.Rows.Add(campos);
            }
        }
    }
}
