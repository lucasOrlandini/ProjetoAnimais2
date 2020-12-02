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
    public class DoacoesController : Controller
    {
        // GET: Release
        public ActionResult Index()
        {
            using (AnimalContexto context = new AnimalContexto())
            {
                var listDB = context.Doacoes.OrderBy(x => x.id).ToList();
                var listViewModel = new List<DoacoesViewModel>();
                listDB.ForEach(x => listViewModel.Add(new DoacoesViewModel
                {
                    id = x.id,
                    nome = x.nome,
                    data = (DateTime)x.data,
                    produto = x.produto,
                    quantidade = x.quantidade,
                    valor = x.valor
                  
                   
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
        public ActionResult Create(DoacoesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    Doacoes doacoes = new Doacoes
                    {
                        id = model.id,
                        nome = model.nome,
                        data = model.data,
                        produto = model.produto,
                        quantidade = model.quantidade,
                        valor = model.valor,
                       

                    };

                    context.Doacoes.Add(doacoes);
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
                var db = context.Doacoes.Find(id);

                DoacoesViewModel model = new DoacoesViewModel
                {
                    id = db.id,
                    nome = db.nome,
                    data =(DateTime)db.data,
                    produto = db.produto,
                    quantidade = db.quantidade,
                    valor = db.valor,
                    

                };

                return View(model);
            }
        }

        // POST: Release/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DoacoesViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    var db = context.Doacoes.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Doação não encontrado!");
                        return View(model);
                    }
                    db.nome = model.nome;
                    db.data = model.data;
                    db.produto = model.produto;
                    db.quantidade = model.quantidade;
                    db.valor = model.valor;
                   
                    

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
                var db = context.Doacoes.Find(id);

                DoacoesViewModel model = new DoacoesViewModel
                {
                   id = db.id,
                   nome = db.nome,
                   data = (DateTime)db.data,
                   produto =db.produto,
                   quantidade = db.quantidade,
                   valor = db.valor,
                   
               };

                return View(model);
            }
        }

        // POST: Release/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DoacoesViewModel model)
        {
            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    var db = context.Doacoes.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Animal não encontrado!");
                        return View(model);
                    }

                    context.Doacoes.Remove(db);
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