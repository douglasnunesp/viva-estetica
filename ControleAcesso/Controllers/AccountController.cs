using System.Web.Mvc;
using System.Web.Security;
using Viva.Estetica.Application.Comandos.Autenticacao;
using Viva.Estetica.Site.Models;

namespace ControleAcesso.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAutenticacaoServico autenticacaoServico;

        public AccountController(IAutenticacaoServico autenticacaoServico)
        {
            this.autenticacaoServico = autenticacaoServico;
        }

        public ActionResult Login(string returnURL)
        {
            ViewBag.ReturnUrl = returnURL;
            return View(new Authentication());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Authentication login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                string errorMessage = string.Empty;
                var vLogin = autenticacaoServico.Autentica(new AutenticacaoCommand() {
                    Senha = login.Senha,
                    Usuario = login.Usuario,
                }, ref errorMessage);

                if (vLogin != null)
                {
                    FormsAuthentication.SetAuthCookie(vLogin.login, false);
                    if (Url.IsLocalUrl(returnUrl)
                    && returnUrl.Length > 1
                    && returnUrl.StartsWith("/")
                    && !returnUrl.StartsWith("//")
                    && returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    Session["Nome"] = vLogin.Nome;
                    Session["Sobrenome"] = vLogin.SobreNome;
                    Session["ClienteId"] = vLogin.Id;
                    return RedirectToAction("Index", "Agenda");
                }
                else
                {
                    ModelState.AddModelError("Usuario", errorMessage);
                    return View(new Authentication());
                }
            }
            return View(login);
        }
    }
}