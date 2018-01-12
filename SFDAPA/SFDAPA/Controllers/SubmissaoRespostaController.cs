using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;
using SFDAPA.Util;

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

            //Montagem da SubmissaoResposta
            SubmissaoResposta SubmissaoResposta = new SubmissaoResposta();
            SubmissaoResposta.Pergunta = Pergunta;
            SubmissaoResposta.Alternativas = Alternativas;
            SubmissaoResposta.Aluno = (Aluno)SessionHelper.Get(SessionKeys.USUARIO);

            Resposta Respostas = new Resposta();

            foreach (Alternativa questoes in SubmissaoResposta.Alternativas)
            {
                Respostas.Add(questoes.Descricao, new[] {"Verdadeira", "Falsa"});
            }

            TempData["SubmissaoReposta"] = SubmissaoResposta;
            ViewBag.Pergunta = SubmissaoResposta.Pergunta;
            return View(Respostas);
        }


        // POST: SubmissaoResposta/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            try
            {
                SubmissaoResposta SubmissaoResposta = new SubmissaoResposta();
                SubmissaoResposta = TempData["SubmissaoReposta"] as SubmissaoResposta;
                List<Alternativa> Lista = new List<Alternativa>();

                foreach (Alternativa AlternativaCorrente in SubmissaoResposta.Alternativas)
                {
                    String chave = "Model.Answers[" + AlternativaCorrente.Descricao + "].Value";
                    AlternativaCorrente.Resposta = form[chave].ToString();
                    Lista.Add(AlternativaCorrente);    
                }

                SubmissaoResposta.Alternativas = Lista;

                gerenciador.Adicionar(SubmissaoResposta);

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