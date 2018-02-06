using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace SFDAPA.Controllers
{
    public class AnaliseController : Controller
    {
        private GerenciadorAnalise gerenciador;

        public AnaliseController()
        {
            gerenciador = new GerenciadorAnalise();
        }

        // GET: Analise
        public ActionResult Index(int id)
        {
            return RedirectToAction("ProcessarResultado", new { controller = "AnaliseController", id = id});
        }

        public ActionResult ProcessarResultado(int id)
        {
            Pergunta Pergunta = new GerenciadorPergunta().Obter(id);
            List<SubmissaoResposta> SubmissaoRespostas = new GerenciadorSubmissaoResposta().ObterPorPergunta(Pergunta);
            List<Alternativa> Alternativas = new GerenciadorAlternativa().ObterPorPergunta(Pergunta);
            List<Boolean> Respostas = new List<Boolean>(); //Armazenar as respostas que estao em String em Boolean
            List<Indice> Indices = new List<Indice>();

            int Contador = 0;

            foreach (Alternativa Alternativa in Alternativas)
            {
                if (Alternativa.Resposta.Equals("Verdadeiro"))
                    Respostas.Add(true);
                else
                    Respostas.Add(false);
                Indices.Add(new Indice(Alternativa));
            }

            foreach(SubmissaoResposta SubmissaoResposta in SubmissaoRespostas)
            {
                for (int x = 0; x < SubmissaoResposta.Alternativas.Count; x++)
                {
                    if (SubmissaoResposta.Respostas.ElementAt(x) == Respostas.ElementAt(x))
                    {
                        Indice IndiceAcerto = Indices.ElementAt(x);
                        IndiceAcerto.QuantAcerto++;
                        Indices.Insert(x, IndiceAcerto);
                    } else
                    {
                        Indice IndiceErro = Indices.ElementAt(x);
                        IndiceErro.QuantErro++;
                        Indices.Insert(x, IndiceErro);
                    }
                }

                Contador++;
            }


            return View();
        }

        // GET: Analise/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Analise/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Analise/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Analise/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Analise/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Analise/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Analise/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
