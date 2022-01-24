using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Condominio
{
    public partial class Cadastro_Apartamento : Form
    {
        public Cadastro_Apartamento()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Close();
            Application.Exit();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            Database database = new Database();
            database.testeConexão();


            //Declaracao das variaveis
            System.String numApartamento;
            System.String numAndar;


            //vamos receber os dados vindo dos textbox's
            numApartamento = txtApartamento.Text;
            numAndar = txtAndar.Text;


            //Armazenar os dados no Database
            database.inserirDadosApartamento(numApartamento, numAndar);
        }
    }
}
