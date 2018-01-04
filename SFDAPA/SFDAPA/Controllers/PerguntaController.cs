using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Models;
using Negocio.Business;

namespace SFDAPA.Controllers
{
    public class PerguntaController : Controller
    {
        private GerenciadorPergunta gerenciador;

        public PerguntaController()
        {
            gerenciador = new GerenciadorPergunta();
        }

        // GET: Pergunta
        public ActionResult Index(int id)
        {
            GerenciadorAssunto Assuntos = new GerenciadorAssunto();
            Assunto Assunto = Assuntos.Obter(id);               //Obter o assunto passado como parâmetro
            ViewBag.Assunto = Assunto; 
            return View(gerenciador.ObterPorAssunto(Assunto)); //Retornar as perguntas referentes a este assunto e enviar a view
        }
 
        // GET: Pergunta/Details/5
        public ActionResult Details(int id)
        {
            return View(gerenciador.Obter(id));
        }

        // GET: Pergunta/Create
        public ActionResult Create(int id)
        {
            GerenciadorAssunto Assuntos = new GerenciadorAssunto();
            Assunto Assunto = Assuntos.Obter(id); //Retorna o assunto passado como parâmetro
            ViewBag.Assunto = Assunto;            //Passo o objeto para a view
            TempData["Assunto"] = Assunto;        //Atribuo o objeto ao TempData para utilizar no métoto de ação do create
            return View();
        }

        // POST: Pergunta/Create
        [HttpPost]
        public ActionResult Create(Pergunta Pergunta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pergunta PerguntaAux = new Pergunta();
                    PerguntaAux.Questao = Pergunta.Questao; //Pego o texto colocado no formulário da view
                    PerguntaAux.Assunto = TempData["Assunto"] as Assunto; //Pego o assunto passado como parâmetro pelo TempData
                    gerenciador.Adicionar(PerguntaAux);

                    return RedirectToAction("Index", new { id = PerguntaAux.Assunto.Codigo });
                }
            }
            catch
            {
            }

            Assunto Aux2 = TempData["Assunto"] as Assunto;
            ViewBag.Assunto = Aux2;            
            TempData["Assunto"] = Aux2;        
            return View();
        }

        // GET: Pergunta/Edit/5
        public ActionResult Edit(int id)
        {
            Pergunta Pergunta = gerenciador.Obter(id);
            Assunto Assunto = Pergunta.Assunto;
            ViewBag.Assunto = Assunto;
            TempData["Pergunta"] = Pergunta;
            return View(gerenciador.Obter(id));
        }

        // POST: Pergunta/Edit/5
        [HttpPost]
        public ActionResult Edit(Pergunta Pergunta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Pergunta PerguntaAux = new Pergunta();
                    PerguntaAux = TempData["Pergunta"] as Pergunta;
                    PerguntaAux.Questao = Pergunta.Questao;
                    gerenciador.Editar(PerguntaAux);
                    return RedirectToAction("Index", new { id = PerguntaAux.Assunto.Codigo });
                }
            }
            catch {}
            Pergunta Aux2 = TempData["Pergunta"] as Pergunta;
            ViewBag.Assunto = Aux2.Assunto;
            TempData["Pergunta"] = Aux2;
            return View();
        }

        // GET: Pergunta/Delete/5
        public ActionResult Delete(int id)
        {
            Pergunta Pergunta = new Pergunta();
            Pergunta = gerenciador.Obter(id);
            ViewBag.Assunto = Pergunta.Assunto.Codigo;
            return View(Pergunta);
        }

        // POST: Pergunta/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                /*
                Pergunta Pergunta = new Pergunta();
                TryUpdateModel(Pergunta, collection.ToValueProvider());
                gerenciador.Remover(Pergunta);
                return RedirectToAction("Index", new { id = Pergunta.Assunto.Codigo });
                */

                Pergunta Pergunta = new Pergunta();
                Pergunta = gerenciador.Obter(id);
                gerenciador.remover(Pergunta);
                return RedirectToAction("Index", new { id = Pergunta.Assunto.Codigo });
            }
            catch
            {
                return View();
            }
        }


        public ActionResult AlterarCondicao(int id)
        {
            Pergunta Pergunta = new Pergunta();
            Pergunta = gerenciador.Obter(id);
            ViewBag.Assunto = Pergunta.Assunto.Codigo;

            if (Pergunta.FlagCondicao == 0) {
                ViewBag.Mensagem = "Tem certeza que você deseja liberar esta pergunta?";
                ViewBag.Botao = "Liberar";
            } else {
                ViewBag.Mensagem = "Tem certeza que você deseja finalizar esta pergunta?";
                ViewBag.Botao = "Encerrar";
              }

            return View(Pergunta);
        }


        [HttpPost]
        public ActionResult AlterarCondicao(int id, FormCollection collection)
        {
            try
            {
                Pergunta Pergunta = new Pergunta();
                Pergunta = gerenciador.Obter(id);

                if (Pergunta.FlagCondicao == 0)
                {
                    Pergunta.FlagCondicao = 1;
                    Pergunta.TextCondicao = "Finalizar";
                } else if (Pergunta.FlagCondicao == 1)
                {
                    Pergunta.FlagCondicao = 2;
                    Pergunta.TextCondicao = "Encerrada";
                }

                gerenciador.Editar(Pergunta);
                return RedirectToAction("Index", new { id = Pergunta.Assunto.Codigo });
            }
            catch
            {
                return View();
            }
        }


    }
}
