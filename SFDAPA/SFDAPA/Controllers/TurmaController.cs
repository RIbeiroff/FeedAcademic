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
    public class TurmaController : Controller
    {
        private GerenciadorTurma gerenciador;

        public TurmaController()
        {
            gerenciador = new GerenciadorTurma();
        }

        // GET: Turma
        public ActionResult Index()
        {
            /*
            List<Turma> turmas = (typeof(Professor) == ((Professor)SessionHelper.Get(SessionKeys.USUARIO)).GetType()) ?
                gerenciador.ObterTodosPorProfessor((Professor)SessionHelper.Get(SessionKeys.USUARIO)) :
                gerenciador.ObterTodos();
                
            int Sessao = (typeof(Professor) == ((Professor)SessionHelper.Get(SessionKeys.USUARIO)).GetType()) ? 0 :
                         (typeof(Aluno) == ((Aluno)SessionHelper.Get(SessionKeys.USUARIO)).GetType()) ? 1 :
                         -1;
                         */

            List<Turma> turmas = new List<Turma>();

            if (typeof(Professor) == (SessionHelper.Get(SessionKeys.USUARIO)).GetType())
            {
               turmas = gerenciador.ObterTodosPorProfessor((Professor)SessionHelper.Get(SessionKeys.USUARIO));
                ViewBag.Sessao = 0;
            } else if (typeof(Aluno) == (SessionHelper.Get(SessionKeys.USUARIO)).GetType())
            {
                turmas = gerenciador.ObterTodosPorAluno((Aluno)SessionHelper.Get(SessionKeys.USUARIO));
                ViewBag.Sessao = 1;
            }
            else
            {
                turmas = gerenciador.ObterTodos();
            }

            return View(turmas);
        }

        // GET: Turma/Details/5
        public ActionResult Details(int id)
        {
            Turma turma = gerenciador.Obter(id);
            return View(turma);
        }

        // GET: Turma/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Turma/Create
        [HttpPost]
        public ActionResult Create(Turma turma)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    turma.Professor = (Professor) SessionHelper.Get(SessionKeys.USUARIO);
                    gerenciador.Adicionar(turma);
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here
            }
            catch
            {
            }
            return View();

        }

        // GET: Turma/Edit/5
        public ActionResult Edit(int id)
        {
            Turma turma = gerenciador.Obter(id);
            return View(turma);
        }

        // POST: Turma/Edit/5
        [HttpPost]
        public ActionResult Edit(Turma turma)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    turma.Professor = (Professor)SessionHelper.Get(SessionKeys.USUARIO);
                    gerenciador.Editar(turma);
                    return RedirectToAction("Index");
                }
            }
            catch { }

            return View(turma);
        }

        // GET: Turma/Delete/5
        public ActionResult Delete(int id)
        {
            Turma turmaAux = gerenciador.Obter(id);
            return View(turmaAux);
        }

        // POST: Turma/Delete/5
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            try
            {
                gerenciador.remover(Convert.ToInt32(collection["Codigo"]));
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
