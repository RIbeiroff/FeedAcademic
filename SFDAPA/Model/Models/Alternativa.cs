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

        [Required(ErrorMessage = "A descri��o deve ter pelo menos 1 caracteres")]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Descri��o da alternativa")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "A resposta deve ser classiicada como V ou F")]
        [RegularExpression("V{1}")]
        [StringLength(1, MinimumLength = 1)]
        [Display(Name = "Reposta")]
        public char Resposta { get; set; }

        public Pergunta Pergunta { get; set; }

        public Alternativa()
        {
        }

        public Alternativa(int Codigo, String Descricao, char Resposta)
        {
            this.Codigo = Codigo;
            this.Descricao = Descricao;
            this.Resposta = Resposta;
        }


    }
}