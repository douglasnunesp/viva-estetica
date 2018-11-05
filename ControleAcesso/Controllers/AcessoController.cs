using Viva.Estetica.Site;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Viva.Estetica.Site.Models;
using Viva.Estetica.Application;
using Viva.Estetica.Application.Queries;
using Viva.Estetica.Application.Comandos.Cliente.Atualiza;
using Viva.Estetica.Application.Comandos.Cliente.Adiciona;

namespace Viva.Estetica.Site.Controllers
{
    public class AcessoController : Controller
    {
        private readonly IClienteQuery clienteQuery;
        private readonly IResultConverter resultConverter;
        private readonly IClienteAtualizaServico clienteAtualizaServico;
        private readonly IClienteAdicionaServico clienteAdicionaServico;

        public AcessoController(IClienteQuery clienteQuery, IResultConverter resultConverter, IClienteAtualizaServico clienteAtualizaServico, IClienteAdicionaServico clienteAdicionaServico)
        {
            this.clienteQuery = clienteQuery;
            this.resultConverter = resultConverter;
            this.clienteAtualizaServico = clienteAtualizaServico;
            this.clienteAdicionaServico = clienteAdicionaServico;
        }


        public ActionResult Index()
        {
            return View(new Authentication());
        }

        public ActionResult Details(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = resultConverter.Map<ClienteModels>(clienteQuery.Seleciona(id));
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModels cliente)
        {
            if (ModelState.IsValid)
            {
                string mensagemErro = string.Empty;
                var command = new ClienteAdicionaCommand()
                {
                    Documento = new Application.Comandos.Cliente.Adiciona.DocumentoCommand()
                    {
                        Passaport = cliente.Documento.Passaport,
                        RG = cliente.Documento.RG
                    },
                    Endereco = new Application.Comandos.Cliente.Adiciona.EnderecoCommand()
                    {
                        Bairro = cliente.Endereco.Bairro,
                        Cep = cliente.Endereco.Cep,
                        Cidade = cliente.Endereco.Cidade,
                        Logradouro = cliente.Endereco.Logradouro,
                        Numero = cliente.Endereco.Numero,
                    },
                    Login = cliente.Login,
                    Nome = cliente.Nome,
                    NumeroCelular = cliente.NumeroCelular,
                    Password = cliente.Password,
                    SobreNome = cliente.SobreNome
                };

                if(clienteAdicionaServico.Processa(command, ref mensagemErro))
                {
                    return RedirectToAction("Login","Account");
                }
                else
                {
                    ModelState.AddModelError("Login", mensagemErro);
                }
            }

            return View(cliente);
        }

        // GET: Acesso/Edit/5
        public ActionResult Edit(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var cliente = resultConverter.Map<ClienteModels>(clienteQuery.Seleciona(id));
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Acesso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteModels cliente)
        {
            if (ModelState.IsValid)
            {
                string mensagemErro = string.Empty;
                var command = new ClienteAtualizaCommand()
                {
                    Id = cliente.Id,
                    Documento = new Application.Comandos.Cliente.Atualiza.DocumentoCommand()
                    {
                        Passaport = cliente.Documento.Passaport,
                        RG = cliente.Documento.RG
                    },
                    Endereco = new Application.Comandos.Cliente.Atualiza.EnderecoCommand()
                    {
                        Bairro = cliente.Endereco.Bairro,
                        Cep = cliente.Endereco.Cep,
                        Cidade = cliente.Endereco.Cidade,
                        Logradouro = cliente.Endereco.Logradouro,
                        Numero = cliente.Endereco.Numero,
                    },
                    Login = cliente.Login,
                    Nome = cliente.Nome,
                    NumeroCelular = cliente.NumeroCelular,
                    Password = cliente.Password,
                    SobreNome = cliente.SobreNome
                };

                if (clienteAtualizaServico.Processa(command, ref mensagemErro))
                {
                    return View(cliente);
                }
                else
                {
                    ModelState.AddModelError("Login", mensagemErro);
                }
                
            }
            return View(cliente);
        }

        // GET: Acesso/Delete/5
        [Authorize(Roles = "Administrador")]
        public ActionResult Delete(Guid id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Authentication authentication = new Authentication();
            if (authentication == null)
            {
                return HttpNotFound();
            }
            return View(authentication);
        }

        // POST: Acesso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Authentication authentication = new Authentication();
            //db.ACESSOes.Remove(aCESSO);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
