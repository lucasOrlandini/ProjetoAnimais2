using Fatec.ProjetoAnimais.DB.Contexto;
using Fatec.ProjetoAnimais.DB.Entitidades;
using Fatec.ProjetoAnimais.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.ProjetoAnimais.Controllers
{
    public class PessoaController : Controller
    {
        // GET: Release
        public ActionResult Index()
        {
            using (AnimalContexto context = new AnimalContexto())
            {
                var listDB = context.Pessoa.OrderBy(x => x.id).ToList();
                var listViewModel = new List<PessoaViewModel>();
                listDB.ForEach(x => listViewModel.Add(new PessoaViewModel
                {
                    id = x.id,
                    cpf = x.cpf,
                    email = x.email,
                    nome = x.nome,
                    sobrenome = x.sobrenome,
                    datanasc = x.datanasc,
                    senha = x.senha,
                    perfil = x.perfil
                }));

                return View(listViewModel);
            }
        }

        // GET: Release/Create
        public ActionResult Create()
        {
            return View();
        }


        // POST: Release/Create
        [HttpPost]
        public ActionResult Create(PessoaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AnimalContexto context = new AnimalContexto())
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
                        perfil = model.perfil

                    };

                    context.Pessoa.Add(pessoa);
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // POST: Release/Createl(Cat


        // GET: Release/Edit/5
        public ActionResult Edit(int id)
        {
            using (AnimalContexto context = new AnimalContexto())
            {
                var db = context.Pessoa.Find(id);

                PessoaViewModel model = new PessoaViewModel
                {
                    id = db.id,
                    cpf = db.cpf,
                    email = db.email,
                    nome = db.nome,
                    sobrenome = db.sobrenome,
                    datanasc = db.datanasc,
                    senha = db.senha,
                    perfil = db.perfil

                };
                return View(model);
            }
        }

        // POST: Release/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PessoaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    var db = context.Pessoa.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Pessoa não encontrada!");
                        return View(model);
                    }
                    db.cpf = model.cpf;
                    db.email = model.email;
                    db.nome = model.nome;
                    db.sobrenome = model.sobrenome;
                    db.datanasc = model.datanasc;
                    db.senha = model.senha;
                    db.perfil = model.perfil;

                    context.Entry(db).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: Release/Delete/5
        public ActionResult Delete(int id)
        {
            using (AnimalContexto context = new AnimalContexto())
            {
                var db = context.Pessoa.Find(id);

                PessoaViewModel model = new PessoaViewModel
                {
                    id = db.id,
                    cpf = db.cpf,
                    email = db.email,
                    nome = db.nome,
                    sobrenome = db.sobrenome,
                    datanasc = db.datanasc,
                    senha = db.senha,
                    perfil = db.perfil

                };

                return View(model);
            }
        }

        // POST: Release/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PessoaViewModel model)
        {
            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    var db = context.Pessoa.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Pessoa não encontrada!");
                        return View(model);
                    }

                    context.Pessoa.Remove(db);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }
    }
}