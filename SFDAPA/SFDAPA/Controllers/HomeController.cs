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
            return RedirectToAction("Login");
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

            SessionHelper.Set(SessionKeys.USUARIO, a1);

            Aluno a2 = new Aluno();
            a2.Nome = "Kaic Barros";
            a2.Codigo = 2;
            a2.Email = "kaicbarros@gmail.com";
            a2.Senha = Criptografia.GerarHashSenha("000000");

            gerenciadorAluno.Adicionar(a1);
            gerenciadorAluno.Adicionar(a2);



            GerenciadorTurma gerenciadorTurma = new GerenciadorTurma();

            Turma turma1 = new Turma();
            turma1.NomeTurma = "Banco de Dados I";
            turma1.Professor = p1;
            turma1.ListaAlunos = new List<Aluno>();
            turma1.ListaAlunos.Add(a1);
            turma1.ListaAlunos.Add(a2);

            Turma turma2 = new Turma();
            turma2.NomeTurma = "Estrutura de Dados II";
            turma2.Professor = p1;
            turma2.ListaAlunos = new List<Aluno>();
            turma2.ListaAlunos.Add(a1);
            turma2.ListaAlunos.Add(a2);

            Turma turma3 = new Turma();
            turma3.NomeTurma = "Engenharia De Software I";
            turma3.Professor = p1;
            turma3.ListaAlunos = new List<Aluno>();
            turma3.ListaAlunos.Add(a2);

            gerenciadorTurma.Adicionar(turma1);
            gerenciadorTurma.Adicionar(turma2);
            gerenciadorTurma.Adicionar(turma3);

            GerenciadorAula gerenciadorAula = new GerenciadorAula();

            Aula aula1 = new Aula();
            aula1.Data = Convert.ToDateTime("22/12/2017");
            aula1.Titulo = "Aula 1";
            aula1.Turma = turma1;

            Aula aula2 = new Aula();
            aula2.Data = Convert.ToDateTime("23/12/2017");
            aula2.Titulo = "Aula 2";
            aula2.Turma = turma1;

            Aula aula3 = new Aula();
            aula3.Data = Convert.ToDateTime("24/12/2017");
            aula3.Titulo = "Aula 3";
            aula3.Turma = turma1;

            gerenciadorAula.Adicionar(aula1);
            gerenciadorAula.Adicionar(aula2);
            gerenciadorAula.Adicionar(aula3);


            Aula aula4 = new Aula();
            aula4.Data = Convert.ToDateTime("24/12/2017");
            aula4.Titulo = "Aula 1";
            aula4.Turma = turma2;

            Aula aula5 = new Aula();
            aula5.Data = Convert.ToDateTime("25/12/2017");
            aula5.Titulo = "Aula 2";
            aula5.Turma = turma2;

            gerenciadorAula.Adicionar(aula4);
            gerenciadorAula.Adicionar(aula5);

            Aula aula6 = new Aula();
            aula6.Data = Convert.ToDateTime("26/12/2017");
            aula6.Titulo = "Aula 1";
            aula6.Turma = turma3;

            gerenciadorAula.Adicionar(aula6);

            GerenciadorAssunto gerenciadorAssunto = new GerenciadorAssunto();
            Assunto Aula1Assunto1 = new Assunto();
            Aula1Assunto1.Aula = aula1;
            Aula1Assunto1.Nome = "DBMS";

            Assunto Aula1Assunto2 = new Assunto();
            Aula1Assunto2.Aula = aula1;
            Aula1Assunto2.Nome = "T-SQL";

            gerenciadorAssunto.Adicionar(Aula1Assunto1);
            gerenciadorAssunto.Adicionar(Aula1Assunto2);

            GerenciadorPergunta gerenciadorPergunta = new GerenciadorPergunta();
            Pergunta Pergunta1Assunto1 = new Pergunta();
            Pergunta1Assunto1.Questao = "Qual a importância do DBMS?";
            Pergunta1Assunto1.Assunto = Aula1Assunto1;

            Pergunta Pergunta2Assunto1 = new Pergunta();
            Pergunta2Assunto1.Questao = "Qual a função do DBMS?";
            Pergunta2Assunto1.Assunto = Aula1Assunto1;
            Pergunta2Assunto1.FlagCondicao = 0;


            Pergunta Pergunta3Assunto1 = new Pergunta();
            Pergunta3Assunto1.Questao = "Qual o significado da sigla DBMS?";
            Pergunta3Assunto1.Assunto = Aula1Assunto1;
            Pergunta3Assunto1.FlagCondicao = 1; // Em aberto 

            gerenciadorPergunta.Adicionar(Pergunta1Assunto1);
            gerenciadorPergunta.Adicionar(Pergunta2Assunto1);
            gerenciadorPergunta.Adicionar(Pergunta3Assunto1);

            GerenciadorAlternativa gerenciadorAlternativa = new GerenciadorAlternativa();

            gerenciadorAlternativa.Adicionar(new Alternativa(1, "Database Management Security", "Falsa", Pergunta3Assunto1));
            gerenciadorAlternativa.Adicionar(new Alternativa(2, "Data Management System", "Falsa", Pergunta3Assunto1));
            gerenciadorAlternativa.Adicionar(new Alternativa(3, "Database Management System", "Verdadeira", Pergunta3Assunto1));
            gerenciadorAlternativa.Adicionar(new Alternativa(4, "Data Machine Security", "Falsa", Pergunta3Assunto1));

        }

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Login(FormCollection form)
        {
            Login Login = new Login();
            Login.Email = form["Email"];
            Login.Senha = form["Senha"];
            Login.Senha = Criptografia.GerarHashSenha(Login.Senha);

            GerenciadorProfessor gerenciadorProfessor = new GerenciadorProfessor();
            GerenciadorAluno gerenciadorAluno = new GerenciadorAluno();

            Professor professor = gerenciadorProfessor.ObterPorLogin(Login);
            Aluno aluno = new Aluno();

            if (professor != null)
            {
                SessionHelper.Set(SessionKeys.USUARIO, professor);
                return RedirectToAction("Index", "Turma");
            }
            else if ( (aluno = gerenciadorAluno.ObterPorAluno(Login)) != null)
            {
                SessionHelper.Set(SessionKeys.USUARIO, aluno);
                return RedirectToAction("Index", "Turma");
            }

            return View();
        }

        // GET: Turma/Create
        public ActionResult Cadastro()
        {

            return View();
        }
    }
}
