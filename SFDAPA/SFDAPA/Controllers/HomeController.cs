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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Simulacao();
            return RedirectToAction("Index","Professor");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Professor()
        {

            return View();
        }

        public ActionResult Aluno()
        {

            return View();
        }

        public void Simulacao()
        {
            GerenciadorProfessor gerenciadorProfessor = new GerenciadorProfessor();
            Professor p1 = new Professor();
            p1.Codigo = 1;
            p1.Email = "andre@ufs.com";
            p1.Instituição = "UFS";
            p1.Senha = Criptografia.GerarHashSenha("qualquercoisa");

            gerenciadorProfessor.Adicionar(p1);

            SessionHelper.Set(SessionKeys.USUARIO, p1);

            GerenciadorAluno gerenciadorAluno = new GerenciadorAluno();
            Aluno a1 = new Aluno();
            a1.Nome = "Jadson Ribeiro dos Santos";
            a1.Codigo = 1;
            a1.Email = "jadson@ufs.com";
            a1.Senha = Criptografia.GerarHashSenha("12345");

            //SessionHelper.Set(SessionKeys.USUARIO, a1);

            Aluno a2 = new Aluno();
            a2.Nome = "Kaic Barros";
            a2.Codigo = 2;
            a2.Email = "kaicbarros@gmail.com";
            a2.Senha = Criptografia.GerarHashSenha("000000");

            gerenciadorAluno.Adicionar(a1);
            gerenciadorAluno.Adicionar(a2);

        }

        // GET: Turma/Create
        public ActionResult Cadastro()
        {

            return View();
        }
    }
}
