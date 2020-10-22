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
    public class AnimalController : Controller
    {
        // GET: Release
        public ActionResult Index()
        {
            using (AnimalContexto context = new AnimalContexto())
            {
                var listDB = context.Animal.OrderBy(x => x.id).ToList();
                var listViewModel = new List<AnimalViewModel>();
                listDB.ForEach(x => listViewModel.Add(new AnimalViewModel
                {
                    id = x.id,
                    cidade_encontrado = x.cidade_encontrado,
                    condicoes = x.condicoes,
                    especie = x.especie,
                    porte = x.porte,
                    raca = x.raca,
                    sexo = x.sexo,
                    vacinas = x.vacinas,
                    situacao = x.situacao
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
        public ActionResult Create(AnimalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    Animal animal = new Animal
                    {
                        id = model.id,
                        cidade_encontrado = model.cidade_encontrado,
                        condicoes = model.condicoes,
                        especie = model.especie,
                        porte = model.porte,
                        raca = model.raca,
                        sexo = model.sexo,
                        vacinas = model.vacinas,
                        situacao = model.situacao

                    };

                    context.Animal.Add(animal);
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
                var db = context.Animal.Find(id);

                AnimalViewModel model = new AnimalViewModel
                {
                    id = db.id,
                    cidade_encontrado = db.cidade_encontrado,
                    condicoes = db.condicoes,
                    especie = db.especie,
                    porte = db.porte,
                    raca = db.raca,
                    sexo = db.sexo,
                    vacinas = db.vacinas,
                    situacao = db.situacao

                };

                return View(model);
            }
        }

        // POST: Release/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AnimalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    var db = context.Animal.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Animal não encontrado!");
                        return View(model);
                    }
                    db.cidade_encontrado = model.cidade_encontrado;
                    db.condicoes = model.condicoes;
                    db.especie = model.especie;
                    db.porte = model.porte;
                    db.raca = model.raca;
                    db.sexo = model.sexo;
                    db.vacinas = model.vacinas;
                    db.situacao = model.situacao;

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
                var db = context.Animal.Find(id);

                AnimalViewModel model = new AnimalViewModel
                {
                    id = db.id,
                    cidade_encontrado = db.cidade_encontrado,
                    condicoes = db.condicoes,
                    especie = db.especie,
                    porte = db.porte,
                    raca = db.raca,
                    sexo = db.sexo,
                    vacinas = db.vacinas,
                    situacao = db.situacao
                };

                return View(model);
            }
        }

        // POST: Release/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AnimalViewModel model)
        {
            try
            {
                using (AnimalContexto context = new AnimalContexto())
                {
                    var db = context.Animal.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Animal não encontrado!");
                        return View(model);
                    }

                    context.Animal.Remove(db);
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