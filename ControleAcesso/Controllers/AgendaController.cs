using Viva.Estetica.Site;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Viva.Estetica.Site.Models;
using Viva.Estetica.Application.Comandos.Agenda.Marca;
using Viva.Estetica.Application.Comandos.Agenda.Atualiza;
using Viva.Estetica.Application.Comandos.Agenda.Remove;
using Viva.Estetica.Application.Queries;
using Viva.Estetica.Application;

namespace Viva.Estetica.Site.Controllers
{
    [Authorize]
    public class AgendaController : Controller
    {
        // GET: Agenda
        private readonly IAgendaMarcaServico agendaMarcaServico;
        private readonly IAgendaAtualizaServico agendaAtualizaServico;
        private readonly IAgendaRemoveServico agendaRemoveServico;
        private readonly IServicoQuery servicoQuery;
        private readonly IAgendaQuery agendaQuery;
        private readonly IResultConverter resultConverter;
        public AgendaController(IAgendaMarcaServico agendaMarcaServico, IAgendaAtualizaServico agendaAtualizaServico, IAgendaRemoveServico agendaRemoveServico, IServicoQuery servicoQuery, IAgendaQuery agendaQuery, IResultConverter resultConverter)
        {
            this.agendaMarcaServico = agendaMarcaServico;
            this.agendaAtualizaServico = agendaAtualizaServico;
            this.agendaRemoveServico = agendaRemoveServico;
            this.servicoQuery = servicoQuery;
            this.agendaQuery = agendaQuery;
            this.resultConverter = resultConverter;
        }

        public ActionResult Index()
        {
            Guid clienteId = (Guid)Session["ClienteId"];
            List<AgendaModels> agendaModels = resultConverter.Map<List<AgendaModels>>(agendaQuery.SelecionaCliente(clienteId)).OrderBy(x=>x.DataAgendamento).ToList();

            return View(agendaModels);
        }

        public ActionResult Criar()
        {
            ViewBag.mensagem = string.Empty;
            var servicos = servicoQuery.Seleciona();
            ViewBag.Servicos = new SelectList(servicos, "Id", "Nome", string.Empty);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(AgendaModels agenda)
        {
            Guid clienteId = (Guid)Session["ClienteId"];
            if (ModelState.IsValid)
            {
                var resultado = agendaMarcaServico.Processa(new AgendaMarcaCommand()
                {
                    ClienteId = clienteId,
                    DataAgendamento = agenda.DataAgendamento,
                    ServicoId = agenda.Servico.Id,
                });
                if (resultado)
                {
                    ViewData["mensagem"] = "Seu agendamento foi criado com sucesso.";
                    return RedirectToAction("Index", "Agenda");
                }
                else
                {
                    ViewData["mensagem"] = "Desculpe ocorreu um erro ao processar sua solicitação, por favor tente novamente ou entre em contato conosco.";
                    return View(agenda);
                }
            }
            return View(agenda);

        }

        public ActionResult Editar(Guid id)
        {
            Guid clienteId = (Guid)Session["ClienteId"];
            AgendaModels agendaModel = resultConverter.Map<AgendaModels>(agendaQuery.Seleciona(id));
            var servicos = servicoQuery.Seleciona();
            ViewBag.Servicos = new SelectList(servicos, "Id", "Nome", agendaModel.Id);
            return View(agendaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(AgendaModels agenda)
        {
            Guid clienteId = (Guid)Session["ClienteId"];
            string mensagem = string.Empty;
            var servicos = servicoQuery.Seleciona();
            ViewBag.Servicos = new SelectList(servicos, "Id", "Nome", agenda.Id);
            if (ModelState.IsValid)
            {
                var resultado = agendaAtualizaServico.Processa(new AgendaAtualizaCommand()
                {
                    Id = agenda.Id,
                    ClienteId = clienteId,
                    DataAgendamento = agenda.DataAgendamento,
                    ServicoId = agenda.Servico.Id,
                }, ref  mensagem);

                if (resultado)
                {
                    ViewBag.mensagem = "Seu alterado foi criado com sucesso.";
                    return RedirectToAction("Index","Agenda");
                }
                else
                {
                    ViewBag.mensagem = mensagem;
                    return View(agenda);
                }
            }
            return View(agenda);

        }

        public ActionResult Remove(Guid id)
        {
            Guid clienteId = (Guid)Session["ClienteId"];
            AgendaModels agendaModel = resultConverter.Map<AgendaModels>(agendaQuery.Seleciona(id));
            return View(agendaModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Remove(AgendaModels agenda)
        {
            Guid clienteId = (Guid)Session["ClienteId"];
            string mensagem = string.Empty;
            if (ModelState.IsValid)
            {
                var resultado = agendaRemoveServico.Processa(new AgendaRemoveCommand() { Id = agenda.Id}, ref mensagem);
                if (resultado)
                {
                    ViewBag.mensagem = "Seu alterado foi criado com sucesso.";
                    return RedirectToAction("Index", "Agenda");
                }
                else
                {
                    ViewBag.mensagem = mensagem;
                    AgendaModels agendaModel = resultConverter.Map<AgendaModels>(agendaQuery.Seleciona(agenda.Id));
                    return View(agendaModel);
                }
            }
            return View(agenda);
        }
    }
}