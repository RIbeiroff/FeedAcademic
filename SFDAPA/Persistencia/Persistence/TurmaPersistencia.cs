﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistence
{
    public class TurmaPersistencia
    {
        private static List<Turma> listaTurma;

        static TurmaPersistencia()
        {
            listaTurma = new List<Turma>();
        }

        public Turma Adicionar(Turma turma)
        {
            turma.Codigo = listaTurma.Count + 1;
            listaTurma.Add(turma);
            return turma;
        }

        public void Editar(Turma turma)
        {
            int posicao = listaTurma.FindIndex(t => t.Codigo == turma.Codigo);
            listaTurma[posicao] = turma;
        }

        public void Remover(int id)
        {
            int posicao = listaTurma.FindIndex(t => t.Codigo == id);
            listaTurma.RemoveAt(posicao);
        }

        public Turma Obter(Func<Turma, bool> where)
        {
            return listaTurma.Where(where).FirstOrDefault();
        }

        public List<Turma> ObterTodos()
        {
            return listaTurma;
        }

        public List<Turma> ObterTodosPorProfessor(Professor Professor)
        {
            return listaTurma.Where(t => t.Professor.Codigo == Professor.Codigo).ToList();
        }

        public List<Turma> ObterTodosPorAluno(Aluno Aluno)
        {
            return listaTurma.Where(t => t.ListaAlunos.Exists(a => a.Codigo == Aluno.Codigo)).ToList(); 
        }
    }
}
