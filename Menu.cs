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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Fecha o form
            Close();

            //Encerra o processo da Thread
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Vou deixar as demais instanciacao dos forms pra voce fazer, somente essa linha de codigo
            Cadastro_Morador cadastro = new Cadastro_Morador();
            cadastro.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Aqui vc instancia o form (cadastrar veiculo)
            Cadastro_Veiculo cadVeiculo = new Cadastro_Veiculo();
            cadVeiculo.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //aqui voce instancia o form cadastrar apartamento
            Cadastro_Apartamento cadApartamento = new Cadastro_Apartamento();
            cadApartamento.Show();
        }
    }
}
