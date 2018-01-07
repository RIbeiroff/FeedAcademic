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
            List<Alternativa> Alternativas = gerenciador.ObterPorPergunta(Pergunta);
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

            if (Alternativa.Resposta.Length == 0)
                Alternativa.Resposta = null;

            return ValidaCreate(Alternativa);
        }

        public ActionResult ValidaCreate(Alternativa Alternativa)
        {
            try
            {
                if (ModelState.IsValid && !string.IsNullOrEmpty(Alternativa.Descricao) && !string.IsNullOrEmpty(Alternativa.Resposta))
                {
                    Alternativa.Pergunta = TempData["Pergunta"] as Pergunta;              
                    gerenciador.Adicionar(Alternativa);

                    return RedirectToAction("Index", new { id = Alternativa.Pergunta.Codigo });
                }
                 else
                    ModelState.AddModelError("", "Por favor, preencha todos os campos");
                
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
            Alternativa Alternativa = gerenciador.Obter(id);
            TempData["Codigo"] = Alternativa.Codigo;
            TempData["Pergunta"] = Alternativa.Pergunta;

            List<SelectListItem> Opcoes = new List<SelectListItem>();
            Opcoes.Add(new SelectListItem { Text = "Verdadeiro", Value = "Verdadeira" });
            Opcoes.Add(new SelectListItem { Text = "Falso", Value = "Falsa" });
            ViewBag.Alternativas = Opcoes;
            ViewBag.Pergunta = Alternativa.Pergunta.Codigo;

            return View(Alternativa);
        }

        // POST: Alternativa/Edit/5
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {

            Alternativa Alternativa = new Alternativa();
            Alternativa.Pergunta = TempData["Pergunta"] as Pergunta;
            Alternativa.Codigo = Convert.ToInt32(form[1]);
            Alternativa.Descricao = form[2];
            Alternativa.Resposta = form[3];

            if (Alternativa.Resposta.Length == 0)
                Alternativa.Resposta = null;

            return ValidaEdit(Alternativa);
        }

        public ActionResult ValidaEdit(Alternativa Alternativa)
        {
            try
            {
                Alternativa.Pergunta = TempData["Pergunta"] as Pergunta;

                if (ModelState.IsValid && !string.IsNullOrEmpty(Alternativa.Descricao) && !string.IsNullOrEmpty(Alternativa.Resposta))
                {
                    gerenciador.Editar(Alternativa);

                    return RedirectToAction("Index", new { id = Alternativa.Pergunta.Codigo });
                }
                else
                    ModelState.AddModelError("", "Por favor, preencha todos os campos");

            }
            catch
            {
            }

            TempData["Pergunta"] = Alternativa.Pergunta;
            ViewBag.Pergunta = Alternativa.Pergunta.Codigo;
            List<SelectListItem> Opcoes = new List<SelectListItem>();
            Opcoes.Add(new SelectListItem { Text = "Verdadeiro", Value = "Verdadeira" });
            Opcoes.Add(new SelectListItem { Text = "Falso", Value = "Falsa" });
            ViewBag.Alternativas = Opcoes;
            int id = Alternativa.Codigo;

            return View(Alternativa);
        }

        // GET: Alternativa/Delete/5
        public ActionResult Delete(int id)
        {
            Alternativa Alternativa = new Alternativa();
            Alternativa = gerenciador.Obter(id);
            ViewBag.Pergunta = Alternativa.Pergunta.Codigo;
            return View(Alternativa);
        }

        // POST: Alternativa/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Alternativa Alternativa = gerenciador.Obter(id);
                gerenciador.Remover(Alternativa);
                return RedirectToAction("Index", new { id = Alternativa.Pergunta.Codigo});
            }
            catch
            {
                return View();
            }
        } 
    }
}
