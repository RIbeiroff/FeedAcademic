
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Model.App_GlobalResources;
using System.ComponentModel.DataAnnotations;


namespace Model.Models
{
    public class Pergunta
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "A descrição da pergunta deve ter pelo menos 5 caracteres")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Pergunta da Questão")]
        public String Questao { get; set; }

        public List<Alternativa> Alternativas { get; set; }
        public Assunto Assunto { get; set; }

        public Pergunta()
        {
            Alternativas = new List<Alternativa>();
        }
            

        public Pergunta(int Codigo, String Questao, List<Alternativa> Alternativas, Assunto Assunto)
        {
            this.Codigo = Codigo;
            this.Questao = Questao;
            this.Alternativas = Alternativas;
            this.Assunto = Assunto;
        }

    }
}