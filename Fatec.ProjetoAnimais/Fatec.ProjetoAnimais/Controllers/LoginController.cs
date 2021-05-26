using Fatec.ProjetoAnimais.DB.Contexto;
using Fatec.ProjetoAnimais.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using Fatec.ProjetoAnimais.DB.Entitidades;
using Fatec.ProjetoAnimais.Sessao;
using Fatec.ProjetoAnimais.Util;

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

            AutismoContext contexto = new AutismoContext();

            //var teste = contexto.db

            Pessoa pessoa = contexto.Pessoa.FirstOrDefault(x => x.email == model.Email && x.senha == model.Senha);

            if (pessoa == null)
            {
                ModelState.AddModelError("", "Usuário ou senha inválido.");
                return View(model);
            }
            else
            {
                ControleSessao.UsuarioLogado = new PessoaViewModel { id = pessoa.id, email = pessoa.email, perfil = pessoa.perfil, nome = pessoa.nome };
                if (pessoa.perfil == (int)PessoaViewModel.ePerfil.Professor)
                {
                    return RedirectToAction("IndexAdmin", "Home");
                }
                else
                {
                    return RedirectToAction("IndexUsuario", "Home");
                }
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
        [HttpGet]
        [AllowAnonymous]
        public  ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public  ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            using (AutismoContext contexto = new AutismoContext())
            {
                Pessoa pessoa = contexto.Pessoa.FirstOrDefault(x => x.email == model.Email);

                if (pessoa == null)
                {
                    //Exibir mensagem que o usuário nao existe
                    ModelState.AddModelError("", "Email não encontrado");
                    return View();
                }

                Email.enviarSenha(model.Email, pessoa.senha);
                ViewBag.Mensagem = "Senha enviada para o email [" + model.Email + "] com sucesso.";
                return View();
            }
        }
    }
    
}