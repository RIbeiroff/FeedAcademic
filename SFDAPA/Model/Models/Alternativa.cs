using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.App_GlobalResources;
using System.ComponentModel.DataAnnotations;


/**
 * 
 */
namespace Model.Models
{
    public class Alternativa
    {

        [Key]
        public int Codigo { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Descri��o da alternativa")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "A resposta deve ser classiicada como Verdadeira ou Falsa")]
        [Display(Name = "Reposta")]
        public String Resposta { get; set; }

        [Required]
        public Pergunta Pergunta { get; set; }

        public Alternativa()
        {
        }

        public Alternativa(int Codigo, String Descricao, String Resposta, Pergunta Pergunta)
        {
            this.Codigo = Codigo;
            this.Descricao = Descricao;
            this.Resposta = Resposta;
            this.Pergunta = Pergunta;
        }


    }
}