using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.IO;


namespace Condominio
{
    class Database
    {

        static System.String connectionString = "Server=localhost;Database=sistema_condominios;Uid=root"; //declaração da string com os parametros do banco
        

        //Vamos testar a conexão antes
        public void testeConexão()
        {
            MySqlConnection mySqlConnection; //Cria a refernencia para classe MySQLConnection
            mySqlConnection = new MySqlConnection(connectionString); //Instancia a classe e passa a connectionString via parametro

            try
            {
                mySqlConnection.Open();   //Abre a conexão

                System.Windows.Forms.MessageBox.Show("CONECTADO COM SUCESSO AO BANCO MEU BROTHER");
                System.Windows.Forms.MessageBox.Show("DEU BOM GRANDE GUILEHRME OPERAÇÕES PROGRAMMER C#");
                
            }
            catch(MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show("DEU RUIM CARA BOM!!!");
                System.Windows.Forms.MessageBox.Show(ex.ToString()); //Vai cair aqui se "Não der bom" kkkk
            }

            mySqlConnection.Close();    //Fecha a conexão
        }


        public void inserirDadosMorador(string nomeCompleto, string dataNascimento, string cpf, string rg)
        {
            MySqlConnection mySqlConnection; //cria uma referência para o MysqlConnection, classe responsável por conectar com o banco
            MySqlCommand mySqlCommand; //Para criar o camando do PLSQL

            try//Tente
            {
                //criação da query PLSQL, passando os parametros dentro da string
                string query = "INSERT INTO SISTEMA_CONDOMINIOS.MORADOR(NOMECOMPLETO, DATANASCIMENTO, CPF, RG) VALUES('" + nomeCompleto + "','" + dataNascimento + "','" + cpf + "','" + rg + "');";

                

                mySqlConnection = new MySqlConnection(connectionString); //Cria a conexão
                mySqlCommand = new MySqlCommand(query, mySqlConnection);//Cria o comando

                mySqlConnection.Open();
                System.Windows.Forms.MessageBox.Show("Conexão já foi testada e está funcionando, falta agora voce fazer a persistencia PROGRAMMER!!!");
                

                mySqlCommand.ExecuteReader(); //Aqui persistimos os dados no banco

                 
                mySqlConnection.Close(); //fecha a conexão
            }
            catch(MySqlException ex)
            {
                //Caiu aqui Deu bom não grande Guilherme operações Programmer
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }

        public void inserirDadosApartamento(string numApartamento, string numAndar)
        {
            MySqlConnection mySqlConnection; //cria uma referência para o MysqlConnection, classe responsável por conectar com o banco
            MySqlCommand mySqlCommand; //Para criar o camando do PLSQL

            try//Tente
            {
                //criação da query PLSQL, passando os parametros dentro da string
                string query = "INSERT INTO SISTEMA_CONDOMINIOS.APARTAMENTO(numApartamento, numAndar) VALUES('" + numApartamento + "','" + numAndar + "');";

                mySqlConnection = new MySqlConnection(connectionString); //Cria a conexão
                mySqlCommand = new MySqlCommand(query, mySqlConnection);//Cria o comando

                mySqlConnection.Open();
                System.Windows.Forms.MessageBox.Show("Teste de Conexão apartamentos");

                mySqlCommand.ExecuteReader(); //Aqui persistimos os dados no banco

                mySqlConnection.Close(); //fecha a conexão

                //apagar os campos automaticamente**********
                

            }
            catch (MySqlException ex)
            {
                //Caiu aqui Deu bom não grande Guilherme operações Programmer
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
        }
    }
}
