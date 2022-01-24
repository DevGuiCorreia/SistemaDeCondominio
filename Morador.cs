using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio
{
    class Morador
    {
        private String nomeCompleto;
        private String dataNascimento;
        private String cpf;
        private String rg;
        public Morador() { }

        public Morador(String nomeMorador, String dataNascimentoMorador, String CPF_Morador, String RG_Morador)
        {
            this.nomeCompleto = nomeMorador;
            this.dataNascimento = dataNascimentoMorador;
            this.cpf = CPF_Morador;
            this.rg = RG_Morador;
        }

        //Gets
        public String getNomeCompleto()
        {
            return nomeCompleto;
        }
        public String getdataNascimento()
        {
            return dataNascimento;
        }

        public String getCPF()
        {
            return cpf;
        }

        public String getRG()
        {
            return rg;       
        }



        //Sets
        public void setNomeCompleto(String nomeCompleto)
        {
            this.nomeCompleto = nomeCompleto;
        }

        public void setDataNascimento(String dataNascimento)
        {
            this.dataNascimento = dataNascimento;
        }

        public void setCPF(String cpf)
        {
            this.cpf = cpf;
        }

        public void setRG(String rg)
        {
            this.rg = rg;
        }
    }
}
