using Fatec.ProjetoAnimais.DB.Contexto;
using Fatec.ProjetoAnimais.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using Fatec.ProjetoAnimais.DB.Entitidades;

namespace Fatec.ProjetoAnimais.Controllers
{
    [Authorize]
    public class LoginController : Controller
    {
        public LoginController()
        {
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Autenticar(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Autenticar(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            AnimalContexto contexto = new AnimalContexto();

            //var teste = contexto.db

            Pessoa pessoa = contexto.Pessoa.FirstOrDefault(x => x.email == model.Email && x.senha == model.Senha);

            if (pessoa == null)
            {
                ModelState.AddModelError("", "Usuário ou senha inválido.");
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }


            // Isso não conta falhas de login em relação ao bloqueio de conta
            // Para permitir que falhas de senha acionem o bloqueio da conta, altere para shouldLockout: true
            //var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            //switch (result)
            //{
            //    case SignInStatus.Success:
            //        return RedirectToLocal(returnUrl);
            //    default:
            //        ModelState.AddModelError("", "Tentativa de login inválida.");
            
            //}
        }
    }
}