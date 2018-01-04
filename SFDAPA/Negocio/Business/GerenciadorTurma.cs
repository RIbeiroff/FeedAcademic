using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;
using Persistencia.Persistence;

namespace Negocio.Business
{
    public class GerenciadorTurma
    {
        private TurmaPersistencia persistencia;

        public GerenciadorTurma()
        {
            persistencia = new TurmaPersistencia();
        }

        public Turma Adicionar(Turma turma)
        {
            persistencia.Adicionar(turma);
            return turma;
        }

        public void Editar(Turma turma)
        {
            persistencia.Editar(turma);
        }

        public void remover(int id)
        {
            persistencia.Remover(id);
        }

        public Turma Obter(int id)
        {
            return persistencia.Obter(e => e.Codigo == id);
        }

        public List<Turma> ObterTodos()
        {
            return persistencia.ObterTodos();
        }

        public List<Turma> ObterTodosPorProfessor(Professor Professor)
        {
            return persistencia.ObterTodosPorProfessor(Professor);
        }

        public List<Turma> ObterTodosPorAluno(Aluno Aluno)
        {
            return persistencia.ObterTodosPorAluno(Aluno);
        }
    }
}
