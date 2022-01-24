using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Chamando o pacote dentro do programa, para usar para criar a conexão com o banco
using System.IO;
using System.Globalization;

namespace Condominio
{
    public partial class Cadastro_Morador : Form
    {
        static System.String connectionString = "Server=localhost;Database=sistema_condominios;Uid=root";
        public Cadastro_Morador()
        {
            InitializeComponent();
            carregarLista(); //Chamar o procedimento no Construtor da Classe
        }

        private void Cadastro_Morador_Load(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close(); //Aqui é somente o Close() mesmo
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            txtNome.Enabled = true; //Toda vez que for cadastrar, habilitar

            Database database = new Database();
            database.testeConexão();
            

            //Declaracao das variaveis
            System.String nomeCompleto;
            System.String dataNascimento;
            System.String cpf;
            System.String rg;


            //vamos receber os dados vindo dos textbox's
            nomeCompleto = txtNome.Text;
            dataNascimento = dtNascimento.Text;
            cpf = txtcpf.Text;
            rg = txtrg.Text;

            //Nesste tipo de declaracao deixamos de forma encapsulada ou melhor, negligenciamos o tamanho, pois, vamos assumir que não sabemos o tamanho
            //da lista. Nesse caso é "Alocação Dinâmica de Memória"
            String[] lista02 = { nomeCompleto, dataNascimento, cpf, rg };

            //Tem como criar a matrix de Strings (objetos) dessa forma
            //Dessa forma deixamos explicito o tamanho da matrix TAM 4
            //Esse tipo de alocação é "Alocação Estática de Memória"
            String[] lista = new string[4] { nomeCompleto, dataNascimento, cpf, rg };

            //Mas iremos usar apenas uma lista de objetos, mas, podemos usar ambas


            //SÃO ADICIONADOS A LISTA EM TEMPO DE EXECUÇÃO
            var listView = new ListViewItem(lista); //Criamos uma variavel do Tipo VAR, que pode ser qualquer tipo de dado, e adicionamos ao objeto ListView
            listView1.Items.Add(listView); //listView1 é o nome do Objeto da lista



            //Armazenar os dados no Database
             database.inserirDadosMorador(nomeCompleto, dataNascimento, cpf, rg);

            clearCampos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Ou podemos fazer um procedimento
            //txtNome.Clear();
            //txtcpf.Clear();
            //txtrg.Clear();

            clearCampos();
        }

        public void clearCampos()
        {
            txtNome.Clear();
            txtcpf.Clear();
            txtrg.Clear();
        }

        private void txtrg_TextChanged(object sender, EventArgs e)
        {

        }

        //Esse procedimento será usado para Carregar a lista com os dados vindo do Database
        public void carregarLista()
        {
            try
            {
                //Peguei prontinho do projeto do Cliente

                //Esta tudo comentado em ingles, depois, se não entender só traduzir

                //São para ATRIBUTOS DE PROPRIEDADES DA LISTA

                // Set the view to show details.
                listView1.View = View.Details;
                // Allow the user to edit item text.
                listView1.LabelEdit = true;
                // Allow the user to rearrange columns.
                listView1.AllowColumnReorder = true;
                // Display check boxes.
                //listView1.CheckBoxes = true;
                // Select the item and subitems when selection is made.
                listView1.FullRowSelect = true;
                // Display grid lines.
                listView1.GridLines = true;
                // Sort the items in the list in ascending order.
                listView1.Sorting = SortOrder.None;
                //Agora vamos criar o cabeçalho da lista

                //Ele adiciona os dados do cabeçalho, pegando o a string do nome do cabelho, o tamnho no nosso caso 150 pixels, e o alinhamento, coloquei para centralizar
                listView1.Columns.Add("NOME COMPLETO", 150, HorizontalAlignment.Center);
                listView1.Columns.Add("DATA NASCIMENTO", 60, HorizontalAlignment.Center);
                listView1.Columns.Add("CPF", 120, HorizontalAlignment.Center);
                listView1.Columns.Add("RG", 120, HorizontalAlignment.Center);


                //Criar a conexão para carregar os dados do Database MySQL
                MySqlConnection mySqlConnection = new MySqlConnection(connectionString);
                mySqlConnection.Open(); //Abre a c onexão

                MySqlCommand cmd; //Classe MYSQLCOMMAND usada para criar PLSQL
                MySqlDataAdapter da; ///Classe usada para Criar PLSQL Adapter de Banco
                DataTable dt;  //Para trabalhar com DataTables
                DataSet ds; //DataSets para carregamento dinamicos também

                cmd = new MySqlCommand("SELECT * FROM SISTEMA_CONDOMINIOS.MORADOR", mySqlConnection);
                da = new MySqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds, "MORADOR");
                mySqlConnection.Close();

                //Faz um loop carregando os dados do banco
                dt = ds.Tables["MORADOR"];
                int i;
                for (i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    //listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                    listView1.Items.Add(dt.Rows[i].ItemArray[1].ToString());            //NOME COMPLETO
                    listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());//DATA NASCIMENTO
                    listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());//CPF 
                    listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());//RG
                }
            }
            catch(MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Vou desabilitar a alteração do dado no nome do Moradora
            txtNome.Enabled = false; //Toda vez que for fazer alteração, travar o nome, para o usuario não mudar sem querer o nome, e dar ruim na query

            //Declara as veriaveis
            System.String nome, dataNascimento, cpf, rg;
            //Recebe os dados para fazer o UPDATE
            nome = txtNome.Text;
            dataNascimento = dtNascimento.Value.ToString("yyyy/MM/dd");
            cpf = txtcpf.Text;
            rg = txtrg.Text;

            System.Int16 id_morador = Convert.ToInt16(localizarIDMorador(nome));

            try
            {
                MySqlConnection connection;
                MySqlCommand command;

                connection = new MySqlConnection(connectionString);
                connection.Open();

                command = new MySqlCommand("UPDATE MORADOR SET NOMECOMPLETO='" +  nome + "',DATANASCIMENTO='" + dataNascimento + "',CPF='" + cpf + "',RG='" + rg + "' WHERE ID_MORADOR='" + id_morador + "'", connection);
                command.ExecuteNonQuery(); //Executa a query

                System.Windows.Forms.MessageBox.Show("Dados alterados com Sucesso!!!");
                connection.Close();//fecha a conexão.

                //Agora precisamos atualizar a lista.
                //segue abaixo o codigo
                //Nossa. estou pegando os TextBox. kkkkkkkkk
                listView1.SelectedItems[0].SubItems[0].Text = nome;
                listView1.SelectedItems[0].SubItems[1].Text = dataNascimento;
                listView1.SelectedItems[0].SubItems[2].Text = cpf;
                listView1.SelectedItems[0].SubItems[3].Text = rg;


                //O ERRO É QUERY MESMO, achei o erro. kkkkk. coisa boba. Programação é assim, umas aspas, virgula, dá ruim em tudo. Compilador não perdoa mesmo.

            }
            catch(MySql.Data.MySqlClient.MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            
        }

        //Esse evento captira os dados da lista na hora que clica na lista
        //Antes de aplicarmos o UPDATE, precisamos capturar os dados selecionados da lista em questão
        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            txtNome.Text        = listView1.SelectedItems[0].SubItems[0].Text;
            dtNascimento.Value  = DateTime.Parse(listView1.SelectedItems[0].SubItems[1].Text); //As demais dão erro pelo formato errado

            //DateTime time = DateTime.ParseExact(listView1.SelectedItems[0].SubItems[1].Text, "yyyy/MM/dd", CultureInfo.InvariantCulture);
            //dtNascimento.Value = time;

            txtcpf.Text         = listView1.SelectedItems[0].SubItems[2].Text;
            txtrg.Text          = listView1.SelectedItems[0].SubItems[3].Text;

            //Abre o banco grande Guilherme
        }

        private System.String localizarIDMorador(string nome)
        {
            System.String id_morador;

            try
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();

                MySqlCommand command;

                command = new MySqlCommand("SELECT ID_MORADOR FROM MORADOR WHERE NOMECOMPLETO='" + nome + "'", connection);
                MySqlDataReader dataReader = command.ExecuteReader();

                //Descobre o ID e aplica a atualização
                while (dataReader.Read())
                {
                    Console.WriteLine("{0}", dataReader.GetString(0));
                    //System.Windows.Forms.MessageBox.Show(dataReader.GetString(0));
                }

                //Chamar outro procedimento para fazer o UPDATE no Banco

                id_morador = dataReader.GetString(0);

                return id_morador;
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }

            return null;
        }
    }
}
