using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistence
{
    public class ProfessorPersistencia
    {
        private static List<Professor> listaProfessor;
    
        static ProfessorPersistencia()
        {
            listaProfessor = new List<Professor>()
            {
                new Professor(1, "breno@ufs.br", "UFS", "Breno Santos", null)
            };
        }

        public Professor Adicinoar(Professor professor)
        {
            professor.Codigo = listaProfessor.Count + 1;
            listaProfessor.Add(professor);
            return professor;
        }

        public void Editar(Professor professor)
        {
            int posicao = listaProfessor.FindIndex(p => p.Codigo == professor.Codigo);
            listaProfessor[posicao] = professor;
        }

        public void Remover(Professor professor)
        {
            int posicao = listaProfessor.FindIndex(p => p.Codigo == professor.Codigo);
            listaProfessor.RemoveAt(posicao);
        }

        public Professor Obter(Func<Professor, bool> where)
        {
            return listaProfessor.Where(where).FirstOrDefault();
        }

        public List<Professor> ObterTodos()
        {
            return listaProfessor;
        }

        public Professor ObterPorLogin(Login login)
        {
            return listaProfessor.Where(p => p.Email.Equals(login.Email) && p.Senha.Equals(login.Senha)).FirstOrDefault();
        }
    }
}
