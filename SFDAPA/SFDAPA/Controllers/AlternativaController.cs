using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace SFDAPA.Controllers
{
    public class AlternativaController : Controller
    {
        private GerenciadorAlternativa gerenciador;

        public AlternativaController()
        {
            gerenciador = new GerenciadorAlternativa();
        }
        // GET: Alternativa
        public ActionResult Index(int id)
        {
            GerenciadorPergunta gerenciadorPergunta = new GerenciadorPergunta();
            Pergunta Pergunta = gerenciadorPergunta.Obter(id);
            ViewBag.Pergunta = Pergunta;
            List<Alternativa> Alternativas = Pergunta.Alternativas.ToList();
            return View(Alternativas);
        }

        // GET: Alternativa/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Alternativa/Create
        public ActionResult Create(int id)
        {
            GerenciadorPergunta gerenciadorPergunta = new GerenciadorPergunta();
            Pergunta Pergunta = gerenciadorPergunta.Obter(id);
            ViewBag.Pergunta = Pergunta;
            TempData["Pergunta"] = Pergunta;
            List<SelectListItem> Opcoes = new List<SelectListItem>();
            Opcoes.Add(new SelectListItem { Text = "Verdadeiro" , Value = "Verdadeira"});
            Opcoes.Add(new SelectListItem { Text = "Falso", Value = "Falsa" });
            ViewBag.Alternativas = Opcoes;
            return View();
        }

        // POST: Alternativa/Create
        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            Alternativa Alternativa = new Alternativa();
            Alternativa.Pergunta = TempData["Pergunta"] as Pergunta;
            Alternativa.Descricao = form[1];
            Alternativa.Resposta = form[2];

            //Alternativa AlternativaAux = new Alternativa();
            return ValidaCreate(Alternativa);
        }

        public ActionResult ValidaCreate(Alternativa Alternativa)
        {
            try
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(Alternativa.Descricao) && !string.IsNullOrEmpty(Alternativa.Resposta))
                {
                    Pergunta Pergunta = new Pergunta();
                    GerenciadorPergunta gerenciadorPergunta = new GerenciadorPergunta();

                    Pergunta = Alternativa.Pergunta;
                    Pergunta.Alternativas.Add(Alternativa);
                    gerenciadorPergunta.Editar(Pergunta);

                    return RedirectToAction("Index", new { id = Pergunta.Codigo });
                }
                else
                    ModelState.AddModelError("", "Preencha os campos satanas");
            }
            catch
            {
            }
            Pergunta PerguntaAux = new Pergunta();
            PerguntaAux = TempData["Pergunta"] as Pergunta;
            ViewBag.Pergunta = PerguntaAux;
            TempData["Pergunta"] = PerguntaAux;
            List<SelectListItem> Opcoes = new List<SelectListItem>();
            Opcoes.Add(new SelectListItem { Text = "Verdadeiro", Value = "Verdadeira" });
            Opcoes.Add(new SelectListItem { Text = "Falso", Value = "Falsa" });
            ViewBag.Alternativas = Opcoes;


            return View();
        }

        // GET: Alternativa/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Alternativa/Edit/5
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

        // GET: Alternativa/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Alternativa/Delete/5
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
