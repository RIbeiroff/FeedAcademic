using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace SFDAPA.Controllers
{
    public class SubmissaoRespostaController : Controller
    {
        private GerenciadorSubmissaoResposta gerenciador;
        
        public SubmissaoRespostaController()
        {
            gerenciador = new GerenciadorSubmissaoResposta();
        }

        // GET: SubmissaoResposta
        public ActionResult Index(int id)
        {
            return RedirectToAction("Create", new { controller = "SubmissaoResposta", id = id});
        }
        
        // GET: SubmissaoResposta/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubmissaoResposta/Create
        public ActionResult Create(int id)
        {
            GerenciadorPergunta GerenciadorPergunta = new GerenciadorPergunta();
            Pergunta Pergunta = GerenciadorPergunta.Obter(id);

            GerenciadorAlternativa GerenciadorAlternativa = new GerenciadorAlternativa();
            List<Alternativa> Alternativas = new List<Alternativa>();

            Alternativas = GerenciadorAlternativa.ObterPorPergunta(Pergunta);

            ViewBag.Pergunta = Pergunta;

            return View(Alternativas);
        }

        // POST: SubmissaoResposta/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                SubmissaoResposta resposta = new SubmissaoResposta();
                String resp = form["1"].ToString();
                return RedirectToAction("Index", new { controller = "Pergunta", id = 1 });

            }
            catch
            {
                return View();
            }
        }

        // GET: SubmissaoResposta/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SubmissaoResposta/Edit/5
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

        // GET: SubmissaoResposta/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubmissaoResposta/Delete/5
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
