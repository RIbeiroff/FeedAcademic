using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model.Models
{
    public class Turma
    {
        [Key]
        public int Codigo { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50, MinimumLength = 1)]
        [DataType(DataType.Text)]
        [Display(Name = "Nome da turma")]
        public String NomeTurma { get; set; }

        public Professor Professor { get; set; }

        public List<Aluno> ListaAlunos { get; set; }

        public Turma() : this(0, null, null, null) { }

        public Turma(int Codigo, String NomeTurma, Professor Professor) : this(Codigo, NomeTurma, Professor, new List<Aluno>()) { }

        public Turma(int Codigo, String NomeTurma, Professor Professor, List<Aluno> ListaAlunos)
        {
            this.Codigo = Codigo;
            this.NomeTurma = NomeTurma;
            this.Professor = Professor;
            this.ListaAlunos = ListaAlunos;
        }
    }
}