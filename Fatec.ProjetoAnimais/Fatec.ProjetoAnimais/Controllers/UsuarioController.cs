using Fatec.ProjetoAnimais.DB.Contexto;
using Fatec.ProjetoAnimais.DB.Entitidades;
using Fatec.ProjetoAnimais.Models;
using System;
using System.Web.Mvc;

namespace Fatec.ProjetoAnimais.Controllers
{
    public class UsuarioController: Controller
    {
     

        // GET: Release/Create

        //definindo que o auto cadastro sempre vai ser o usuário
        public ActionResult AutoCadastro()
        {
            var model = new PessoaViewModel {perfil = (int)PessoaViewModel.ePerfil.Aluno };
            return View(model);
        }


        // POST: Release/Create
        [HttpPost]
        public ActionResult AutoCadastro(PessoaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AutismoContext context = new AutismoContext())
                {
                    Pessoa pessoa = new Pessoa
                    {
                        id = model.id,
                        cpf = model.cpf,
                        email = model.email,
                        nome = model.nome,
                        sobrenome = model.sobrenome,
                        datanasc = model.datanasc,
                        senha = model.senha,
                        perfil = (int)PessoaViewModel.ePerfil.Aluno

                    };

                    context.Pessoa.Add(pessoa);
                    context.SaveChanges();

                    return RedirectToAction("Autenticar","Login");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
    }
}