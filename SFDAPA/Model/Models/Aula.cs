
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
    public class Aula
    {

        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "A data é no formato DD/MM/AAAA")]
        [DataType (DataType.Date)]
       // [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O título da aula deve ter pelo menos 1 caractere")]
        [StringLength(40, MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Título")]
        public String Titulo { get; set; }

        public Turma Turma { get; set; }

        public Aula() { }

        public Aula(int Codigo, DateTime Data, String Titulo, Turma turma)
        {
            this.Codigo = Codigo;
            this.Data = Data;
            this.Titulo = Titulo;
            this.Turma = turma;
        }

    }
}