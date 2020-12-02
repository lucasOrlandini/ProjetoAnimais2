using Fatec.ProjetoAnimais.DB.Contexto;
using Fatec.ProjetoAnimais.DB.Entitidades;
using Fatec.ProjetoAnimais.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

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
                    situacao = x.situacao,
                    Data_adocao = x.Data_adocao
                    
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
                        situacao = model.situacao,
                        Data_adocao = model.Data_adocao



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
                    situacao = db.situacao,
                    Data_adocao = db.Data_adocao


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
                    db.Data_adocao = model.Data_adocao;


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
                    situacao = db.situacao,
                    Data_adocao = db.Data_adocao


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
        public ActionResult ListaAdocao(String Mensagem = "")
        {
            using (AnimalContexto context = new AnimalContexto())
            {
                var listDB = context.Animal.Where(x => x.situacao == (int)AnimalViewModel.eSituacaoAnimal.Disponivel).OrderBy(x => x.especie).ToList();
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
                    situacao = x.situacao,
                    Data_adocao = x.Data_adocao

                }));

                ViewBag.Mensagem = Mensagem;

                return View(listViewModel);
            }
        }


        public ActionResult Adotar(int id)
        {

            using (AnimalContexto context = new AnimalContexto())
            {
                var db = context.Animal.Find(id);

                db.situacao = (int)AnimalViewModel.eSituacaoAnimal.Indisponivel;
                db.Data_adocao = DateTime.Now;


                context.Entry(db).State = EntityState.Modified;
                context.SaveChanges();
            }

            return RedirectToAction("ListaAdocao", new RouteValueDictionary(
    new { controller = "Animal", action = "ListaAdocao", Mensagem = "Animal adotado com sucesso!" }));

           

        }
    }
}