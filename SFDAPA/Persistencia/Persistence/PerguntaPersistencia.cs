﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Models;

namespace Persistencia.Persistence
{
    public class PerguntaPersistencia
    {
        private static List<Pergunta> listaPerguntas;

        static PerguntaPersistencia()
        {
            listaPerguntas = new List<Pergunta>();
        }

        public Pergunta Adicionar(Pergunta pergunta)
        {
            pergunta.Codigo = listaPerguntas.Count + 1;
            listaPerguntas.Add(pergunta);
            return pergunta;
        }

        public void Editar(Pergunta pergunta)
        {
            int posicao = listaPerguntas.FindIndex(p => p.Codigo == pergunta.Codigo);
            listaPerguntas[posicao] = pergunta;
        }

        public void Remover(Pergunta pergunta)
        {
            int posicao = listaPerguntas.FindIndex(e => e.Codigo == pergunta.Codigo);
            listaPerguntas.RemoveAt(posicao);
        }

        public Pergunta Obter(Func<Pergunta, bool> where)
        {
            return listaPerguntas.Where(where).FirstOrDefault();
        }

        public List<Pergunta> ObterTodos()
        {
            return listaPerguntas;
        }

        public List<Pergunta> ObterPorAssunto(Assunto Assunto)
        {
            return listaPerguntas.Where(a => a.Assunto == Assunto).ToList();
        }

        public List<Pergunta> ObterPorAssuntoECondicao(Assunto Assunto)
        {
            return listaPerguntas.Where(a => a.Assunto == Assunto).Where(p => p.FlagCondicao == 1).ToList();
        }

    }
}
