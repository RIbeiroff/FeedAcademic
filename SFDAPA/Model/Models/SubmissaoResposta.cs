
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
    public class SubmissaoResposta
    {
        [Key]
        public int Codigo { get; set; }

        [Required]
        public Pergunta Pergunta { get; set; }

        [Required]
        public Aluno Aluno { get; set; }

        public List<Alternativa> Alternativas;
        public List<Boolean> Respostas;
        
        public SubmissaoResposta(){
            Alternativas = new List<Alternativa>();
            Respostas = new List<Boolean>();
        }

        public SubmissaoResposta(int Codigo, Pergunta Pergunta, Aluno Aluno)
        {
            this.Codigo = Codigo;
            this.Pergunta = Pergunta;
            this.Aluno = Aluno;
            Alternativas = new List<Alternativa>();
            Respostas = new List<Boolean>();
        }

        public void Enviar(){}

        public void Alterar(){}

        public void Visualizar()
        {
            // TODO implement here
        }

    }
}