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
    public class ParceiroController : Controller
    {
        // GET: Release
        public ActionResult Index()
        {
            using (AnimalContexto context = new AnimalContexto())
            {
                var listDB = context.Parceiro.OrderBy(x => x.id).ToList();
                var listViewModel = new List<ParceiroViewModel>();
                listDB.ForEach(x => listViewModel.Add(new ParceiroViewModel
                {
                    id = x.id,
                    nome = x.nome,
                    telefone = x.telefone,
                    email = x.email,
                    endereco = x.endereco,
                   motivosParceria = x.motivosParceria,
                    cnpjCpf = x.cnpjCpf
                   
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
        public ActionResult Create(ParceiroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    Parceiro parceiro = new Parceiro
                    {
                        id = model.id,
                        nome = model.nome,
                        telefone = model.telefone,
                        email = model.email,
                        endereco = model.endereco,
                        motivosParceria = model.motivosParceria,
                        cnpjCpf = model.cnpjCpf

                    };

                    context.Parceiro.Add(parceiro);
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
                var db = context.Parceiro.Find(id);

                ParceiroViewModel model = new ParceiroViewModel
                {
                    id = db.id,
                    nome = db.nome,
                    telefone = db.telefone,
                    email = db.email,
                    endereco = db.endereco,
                    motivosParceria = db.motivosParceria,
                    cnpjCpf = db.cnpjCpf

                };

                return View(model);
            }
        }

        // POST: Release/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ParceiroViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    var db = context.Parceiro.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Parceiro não encontrado!");
                        return View(model);
                    }
                    db.nome = model.nome;
                    db.telefone = model.telefone;
                    db.email = model.email;
                    db.endereco = model.endereco;
                    db.motivosParceria = model.motivosParceria;
                    db.cnpjCpf = model.cnpjCpf;
                    

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
                var db = context.Parceiro.Find(id);

                ParceiroViewModel model = new ParceiroViewModel
                {
                   id = db.id,
                   nome = db.nome,
                   telefone = db.telefone,
                   email = db.email,
                   endereco = db.endereco,
                   motivosParceria = db.motivosParceria,
                   cnpjCpf = db.cnpjCpf
               };

                return View(model);
            }
        }

        // POST: Release/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ParceiroViewModel model)
        {
            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    var db = context.Parceiro.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Animal não encontrado!");
                        return View(model);
                    }

                    context.Parceiro.Remove(db);
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