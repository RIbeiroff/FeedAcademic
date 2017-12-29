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
    public class AulaController : Controller
    {
        private GerenciadorAula gerenciador;
        public AulaController()
        {
            gerenciador = new GerenciadorAula();
        }



        public ActionResult Index(int id)
        {
            int IdTurma = id;
            GerenciadorTurma Turmas = new GerenciadorTurma();
            Turma Turma = Turmas.Obter(IdTurma);
            List<Aula> aulas = gerenciador.ObterTodosPorTurma(Turma);
            ViewBag.Turma = Turma;

            return View(aulas);
        }

        // GET: Aula/Details/5
        public ActionResult Details(int id)
        {
            Aula aula = gerenciador.Obter(id);
            return View(aula);
        }

        // GET: Aula/Create
        public ActionResult Create(int id)
        {

            //GerenciadorTurma turma = new GerenciadorTurma();
            //            List<Turma> turmas = turma.ObterTodos();
            //          List<SelectListItem> itens = new List<SelectListItem>();
            //        itens.Add(new SelectListItem { Text = "Selecione a Turma", Value = "0", Selected = true });

            /*      for (int i = 0; i < turmas.Count; i++)
                  {
                      itens.Add(new SelectListItem { Text = (turmas[i].Codigo + " - " + turmas[i].NomeTurma), Value = ""+turmas[i].Codigo });
                  }
                  */
            //ViewBag.Turma = itens;
            int idTurma = id;
            GerenciadorTurma gerenciadorTurma = new GerenciadorTurma();
            Turma Turma = gerenciadorTurma.Obter(idTurma);
            ViewBag.Turma = Turma;
            TempData["TurmaAtual"] = Turma; 
            return View();
        }

        // POST: Aula/Create
        [HttpPost]
        public ActionResult Create(Aula Aula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Aula AulaAux = new Aula();
                    //Aula.Data = Convert.ToDateTime(form["Data"]);
                    AulaAux.Data = Aula.Data;
                    AulaAux.Titulo = Aula.Titulo;
                    AulaAux.Turma = TempData["TurmaAtual"] as Turma;
                    //Aula.Titulo = form["Titulo"];
                    //Aula.Turma = TempData["TurmaAtual"] as Turma;
                    gerenciador.Adicionar(AulaAux);
                    return RedirectToAction("Index", new { id = AulaAux.Turma.Codigo });
                }
            }
            catch
            {
            }
            Turma Turma = TempData["TurmaAtual"] as Turma;
            ViewBag.Turma = Turma;
            TempData["TurmaAtual"] = Turma;
            return View();
        }

        // GET: Aula/Edit/5
        public ActionResult Edit(int id)
        {
            /*
            GerenciadorTurma turma = new GerenciadorTurma();
            List<Turma> turmas = turma.ObterTodos();
            List<SelectListItem> itens = new List<SelectListItem>();
            itens.Add(new SelectListItem { Text = "Selecione a Turma", Value = "0", Selected = true });

            for (int i = 0; i < turmas.Count; i++)
            {
                itens.Add(new SelectListItem { Text = (turmas[i].Codigo + " - " + turmas[i].NomeTurma), Value = "" + turmas[i].Codigo });
            }

    */
            Aula aula = gerenciador.Obter(id);
            ViewBag.Turma = aula.Turma.Codigo;
            TempData["Aula"] = aula;
            return View(aula);
        }

        // POST: Aula/Edit/5
        [HttpPost]
        public ActionResult Edit(Aula Aula)
        {
            try
            {

                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    Aula AulaAux = new Aula();
                    AulaAux = TempData["Aula"] as Aula;
                    AulaAux.Data = Aula.Data;
                    AulaAux.Titulo = AulaAux.Titulo;
                    gerenciador.Editar(AulaAux);
                    return RedirectToAction("Index", new { id = AulaAux.Turma.Codigo});
                }
            }
            catch
            {
            }
            Aula AulaAux2 = new Aula();
            AulaAux2 = TempData["Aula"] as Aula;
            ViewBag.Turma = AulaAux2.Turma.Codigo; //Realimentando o viewbag e tempdata, para evitar dar erro caso 
            TempData["Aula"] = AulaAux2;          // o usuário clique em voltar após tentar salvar um model inválido
            return View();

        }

        // GET: Aula/Delete/5
        public ActionResult Delete(int id)
        {
            Aula aula = gerenciador.Obter(id);
            ViewBag.Turma = aula.Turma.Codigo;
            return View(aula);
        }

        // POST: Aula/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Aula aula = gerenciador.Obter(id);
                gerenciador.Remover(aula);
                return RedirectToAction("Index", new { id = aula.Turma.Codigo });
            }
            catch
            {
                return View();
            }
        }
    }
}
