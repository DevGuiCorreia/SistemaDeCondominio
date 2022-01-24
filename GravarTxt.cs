using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Condominio
{
    class GravarTxt
    {
        public void GravarTxtMorador(string nomeCompleto, string dataNascimento, string cpf, string rg)
        {
            //tentativa de conversao pro .txt
            StreamWriter swMorador = new StreamWriter("Morador.txt");

            //entrada de dados string
            swMorador.WriteLine(nomeCompleto + dataNascimento + cpf + rg);

            //fecha escritura de dados
            swMorador.Close();

        }
    }
}
