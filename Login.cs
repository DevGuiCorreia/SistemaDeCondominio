using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Condominio
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = "guilherme";
            string senha = "123";

            login = textBox1.Text;
            senha = textBox2.Text;

            if(login == "guilherme" && senha == "123")
            {
                //Console.WriteLine("Cadastro realizado com sucesso!!");
                System.Windows.Forms.MessageBox.Show("Login realizado com sucesso!!");
                limparcampos();
                verificarCampos();

                
                //Cria uma instancia para a classe Form propriamente dito
                Menu m = new Menu();
                //referencia do objeto "m" "." ponto chama o evento "show" para mostrar o form
                m.Show();

                //Fecha o form atual, Login no caso
                this.Hide();

            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Login incorreto!");
                limparcampos();
                verificarCampos();
            }
        }
        public void limparcampos()
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                textBox1.Clear();
                textBox2.Clear();
            }
        }

        public void verificarCampos()
        {
            if( textBox1.Text == "" && textBox2.Text == "")
            {
                System.Windows.Forms.MessageBox.Show("Preencha os campos!!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //faz o fechar aqui
            Close();

            Application.Exit();
        }
    }
}