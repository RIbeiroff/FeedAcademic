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

        [Required(ErrorMessage = "A descrição da resposta deve ter pelo menos 1 caractere")]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.Text)]
        [Display(Name = "Descrição da alternativa")]
        public String Descricao { get; set; }

        [Required(ErrorMessage = "A resposta deve ser classiicada como Verdadeira ou Falsa")]
        [StringLength(10, MinimumLength = 2)]
        [Display(Name = "Reposta")]
        public String Resposta { get; set; }

        [Required]
        public Pergunta Pergunta { get; set; }

        public Alternativa()
        {
        }

        public Alternativa(int Codigo, String Descricao, String Resposta)
        {
            this.Codigo = Codigo;
            this.Descricao = Descricao;
            this.Resposta = Resposta;
        }


    }
}