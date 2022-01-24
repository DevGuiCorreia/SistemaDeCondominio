using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condominio
{
    class Apartamento
    {
        private String numApartamento;
        private String numAndar;

        public Apartamento(String numeroApartamento, String numeroAndar)
        {
            this.numApartamento = numeroApartamento;
            this.numAndar = numeroAndar;
        }

        //gets
        public String getNumApartamento()
        {
            return numApartamento;
        }
        public String getNumAndar()
        {
            return numAndar;
        }

        //sets
        public void setNumApartamento(String numApartamento)
        {
            this.numApartamento = numApartamento;
        }
        public void setNumAndar(String numAndar)
        {
            this.numAndar = numAndar;
        }
    }

   
}
