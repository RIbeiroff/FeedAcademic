using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Model.App_GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Indice
    {
        public Alternativa Alternativa { get; set; }
        public int QuantAcerto {get; set;}
        public int QuantErro { get; set; }

        public Indice()
        {
            Alternativa = new Alternativa();
            this.QuantAcerto = this.QuantErro = 0;
        }

        public Indice(Alternativa Alternativa)
        {
            this.Alternativa = Alternativa;
            this.QuantAcerto = this.QuantErro = 0;
        }
    }
}
