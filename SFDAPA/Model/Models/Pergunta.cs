
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

        [Required(ErrorMessage = "A descri��o da pergunta deve ter pelo menos 5 caracteres")]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Pergunta da Quest�o")]
        public String Questao { get; set; }

        public Assunto Assunto { get; set; }
        public int FlagCondicao {get; set;} //0 - Cadastrada, 1 - Em aberto, 2 - Finalizada
        public int FlagSubmissaoResposta { get; set; } // 0 - n�o houve submissao, 1 - houve submissao
        public String TextCondicao { get; set;}

        public Pergunta()
        {
            FlagCondicao = 0;
            TextCondicao = "Liberar   ";    
        }
            

        public Pergunta(int Codigo, String Questao, List<Alternativa> Alternativas, Assunto Assunto)
        {
            this.Codigo = Codigo;
            this.Questao = Questao;
            this.Assunto = Assunto;
        }

    }
}