using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace SFDAPA.Controllers
{
    public class AssuntoController : Controller
    {
        private GerenciadorAssunto gerenciador;

        public AssuntoController()
        {
            gerenciador = new GerenciadorAssunto();
        }

        // GET: Assunto
        public ActionResult Index(int id)
        {
            GerenciadorAula GerenciadorAula = new GerenciadorAula();
            Aula Aula = GerenciadorAula.Obter(id); // Obtendo a aula passada por parâmetro pela Index
            ViewBag.Aula = Aula;
            return View(gerenciador.ObterTodosPorAula(Aula)); // Retornando a View Index os Assuntos referentes a aula
        }

        // GET: Assunto/Details/5
        public ActionResult Details(int id)
        {
            Assunto Assunto = gerenciador.Obter(id);
            ViewBag.Aula = Assunto.Aula.Codigo;
            return View(Assunto);
        }

        // GET: Assunto/Create
        public ActionResult Create(int id)
        {
            GerenciadorAula GerenciadorAula = new GerenciadorAula();
            Aula Aula = GerenciadorAula.Obter(id); //Obtendo a aula através do ID
            ViewBag.Aula = Aula; // Jogando a aula no viewbag para exibir seu título na view
            TempData["AulaAtual"] = Aula; //Atribuindo a Aula ao TempData para poder ser usada no HTTPOST do método create
            return View();
        }

        // POST: Assunto/Create
        [HttpPost]
        public ActionResult Create(Assunto Assunto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Assunto AssuntoAux = new Assunto();
                    AssuntoAux.Nome = Assunto.Nome;
                    AssuntoAux.Aula = TempData["AulaAtual"] as Aula;
                    gerenciador.Adicionar(AssuntoAux);
                    return RedirectToAction("Index", new { id = AssuntoAux.Aula.Codigo });
                }
           }
            catch
            {
            }
            Aula AulaAux2 = new Aula();
            AulaAux2 = TempData["AulaAtual"] as Aula;
            ViewBag.Aula = AulaAux2; // Realimentando ViewBag
            TempData["AulaAtual"] = AulaAux2; // Realimentando TempData

            return View();
        }

        // GET: Assunto/Edit/5
        public ActionResult Edit(int id)
        {
            Assunto Assunto = new Assunto();
            Assunto = gerenciador.Obter(id);
            ViewBag.Aula = Assunto.Aula.Codigo;
            TempData["Assunto"] = Assunto;
            return View(Assunto);
        }

        // POST: Assunto/Edit/5
        [HttpPost]
        public ActionResult Edit(Assunto Assunto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Assunto AssuntoAux = TempData["Assunto"] as Assunto;
                    AssuntoAux.Nome = Assunto.Nome;
                    gerenciador.Editar(AssuntoAux);
                    return RedirectToAction("Index", new { id = AssuntoAux.Aula.Codigo });
                }
            }
            catch
            {
            }

            Assunto AssuntoAux2 = new Assunto();
            AssuntoAux2 = TempData["Assunto"] as Assunto;
            ViewBag.Aula = AssuntoAux2.Aula.Codigo;
            TempData["Assunto"] = AssuntoAux2;
            return View();
        }

        // GET: Assunto/Delete/5
        public ActionResult Delete(int id)
        {
            Assunto Assunto = gerenciador.Obter(id);
            ViewBag.Aula = Assunto.Aula;
            TempData["Aula"] = Assunto.Aula;
            return View(Assunto);
        }

        // POST: Assunto/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Assunto assunto = new Assunto();
                TryUpdateModel(assunto, collection.ToValueProvider());
                gerenciador.Remover(assunto);
                return RedirectToAction("Index", "Assunto", new { id = (TempData["Aula"] as Aula).Codigo });
            }
            catch
            {
                return View();
            }
        }
    }
}
