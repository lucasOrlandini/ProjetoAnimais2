using Fatec.ProjetoAnimais.DB.Contexto;
using Fatec.ProjetoAnimais.DB.Entitidades;
using Fatec.ProjetoAnimais.Models;
using Fatec.ProjetoAnimais.Sessao;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fatec.ProjetoAnimais.Controllers
{
    public class AtividadeController : Controller
    {
        // GET: Release
        public ActionResult Index()
        {
            using (AutismoContext context = new AutismoContext())
            {
                var listTpAtividadeDB = context.TipoAtividade.ToList();
                var listAlunoDB = context.Pessoa.Where(p => p.perfil == (int)PessoaViewModel.ePerfil.Aluno).ToList();


                var listDB = context.Atividade.OrderBy(x => x.id).ToList();
                var listViewModel = new List<AtividadeViewModel>();



                foreach (var atvBD in listDB)
                {
                    var alunoBD = listAlunoDB.FirstOrDefault(x => x.id == atvBD.idAluno);
                    var alunoViewModel = new PessoaViewModel
                    {
                        id = alunoBD.id,
                        nome = alunoBD.nome,
                        sobrenome = alunoBD.sobrenome,
                        email = alunoBD.email
                    };

                    var tipoAtividadeBD = listTpAtividadeDB.FirstOrDefault(x => x.id == atvBD.idTipoAtividade);
                    var tipoAtividadeViewModel = new TipoAtividadeViewModel
                    {
                        id = alunoBD.id,
                        descricaoTipoAtividade = tipoAtividadeBD.descricaoTipoAtividade
                    };

                    listViewModel.Add(new AtividadeViewModel
                    {
                        id = atvBD.id,
                        nomeAtividade = atvBD.nomeAtividade,
                        descricaoAtividade = atvBD.descricaoAtividade,
                        idAluno = atvBD.idAluno,
                        aluno = alunoViewModel,
                        dataEntrega = atvBD.dataEntrega,
                        idTipoAtividade = atvBD.idTipoAtividade,
                        tipoAtividade = tipoAtividadeViewModel
                    });
                }

                return View(listViewModel);
            }
        }


        public ActionResult TipoAtividade2(int id)
        {
            using (AutismoContext context = new AutismoContext())
            {
                var db = context.Atividade.Find(id);

                AtividadeViewModel model = new AtividadeViewModel
                {
                    id = db.id,
                    nomeAtividade = db.nomeAtividade,
                    descricaoAtividade = db.descricaoAtividade,
                    idAluno = db.idAluno,
                    dataEntrega = db.dataEntrega,
                    idTipoAtividade = db.idTipoAtividade
                };

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult TipoAtividade2(AtividadeViewModel model)
        {
            try
            {
                using (AutismoContext context = new AutismoContext())
                {
                    var db = context.Atividade.FirstOrDefault(x => x.id == model.id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Atividade não encontrada!");
                        return View(model);
                    }
                    db.resultadoAtividade = model.resultadoAtividade;
                    db.dataConclusao = DateTime.Now;

                    context.Entry(db).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("AtividadesAluno", "Atividade");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        public ActionResult TipoAtividade1(int id)
        {
            using (AutismoContext context = new AutismoContext())
            {
                var db = context.Atividade.Find(id);

                AtividadeViewModel model = new AtividadeViewModel
                {
                    id = db.id,
                    nomeAtividade = db.nomeAtividade,
                    descricaoAtividade = db.descricaoAtividade,
                    idAluno = db.idAluno,
                    dataEntrega = db.dataEntrega,
                    idTipoAtividade = db.idTipoAtividade
                };

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult TipoAtividade1(AtividadeViewModel model)
        {
            try
            {
                using (AutismoContext context = new AutismoContext())
                {
                    var db = context.Atividade.FirstOrDefault(x =>x.id==model.id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Atividade não encontrada!");
                        return View(model);
                    }
                    db.resultadoAtividade = model.resultadoAtividade;
                    db.dataConclusao = DateTime.Now;

                    context.Entry(db).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("AtividadesAluno", "Atividade");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }


        public ActionResult AtividadesAluno()
        {
            using (AutismoContext context = new AutismoContext())
            {
                var listTpAtividadeDB = context.TipoAtividade.ToList();
                var listAlunoDB = context.Pessoa.Where(p => p.perfil == (int)PessoaViewModel.ePerfil.Aluno).ToList();


                var listDB = context.Atividade.Where(x => x.idAluno == ControleSessao.UsuarioLogado.id).OrderBy(x => x.id).ToList();
                var listViewModel = new List<AtividadeViewModel>();


                foreach (var atvBD in listDB)
                {
                    var alunoBD = listAlunoDB.FirstOrDefault(x => x.id == atvBD.idAluno);
                    var alunoViewModel = new PessoaViewModel
                    {
                        id = alunoBD.id,
                        nome = alunoBD.nome,
                        sobrenome = alunoBD.sobrenome,
                        email = alunoBD.email
                    };

                    var tipoAtividadeBD = listTpAtividadeDB.FirstOrDefault(x => x.id == atvBD.idTipoAtividade);
                    var tipoAtividadeViewModel = new TipoAtividadeViewModel
                    {
                        id = alunoBD.id,
                        descricaoTipoAtividade = tipoAtividadeBD.descricaoTipoAtividade
                    };

                    listViewModel.Add(new AtividadeViewModel
                    {
                        id = atvBD.id,
                        nomeAtividade = atvBD.nomeAtividade,
                        descricaoAtividade = atvBD.descricaoAtividade,
                        idAluno = atvBD.idAluno,
                        aluno = alunoViewModel,
                        dataEntrega = atvBD.dataEntrega,
                        idTipoAtividade = atvBD.idTipoAtividade,
                        tipoAtividade = tipoAtividadeViewModel,
                        dataConclusao = atvBD.dataConclusao,
                        resultadoAtividade= atvBD.resultadoAtividade
                    });
                }

                return View(listViewModel);
            }
        }

        // GET: Release/Create
        public ActionResult Create()
        {
            this.PreencherViewBags();

            return View();
        }

        private void PreencherViewBags()
        {
            using (AutismoContext context = new AutismoContext())
            {
                var listDB = context.Pessoa.Where(p => p.perfil == (int)PessoaViewModel.ePerfil.Aluno).OrderBy(x => x.nome).ToList();
                var listViewModel = new List<PessoaViewModel>();
                listDB.ForEach(x => listViewModel.Add(new PessoaViewModel
                {
                    id = x.id,
                    nome = x.nome,
                    sobrenome = x.sobrenome,
                    email = x.email
                }));

                ViewBag.idAluno = listViewModel;

                var listTpAtividadeDB = context.TipoAtividade.OrderBy(x => x.descricaoTipoAtividade).ToList();
                var listTpAtividadeViewModel = new List<TipoAtividadeViewModel>();
                listTpAtividadeDB.ForEach(x => listTpAtividadeViewModel.Add(new TipoAtividadeViewModel
                {
                    id = x.id,
                    descricaoTipoAtividade = x.descricaoTipoAtividade
                }));

                ViewBag.idTipoAtividade = new SelectList
                (
                    listTpAtividadeViewModel,
                    "id",
                    "descricaoTipoAtividade"
                );
            }
        }


        // POST: Release/Create
        [HttpPost]
        public ActionResult Create(AtividadeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AutismoContext context = new AutismoContext())
                {
                    foreach (var aluno in model.AlunosSelecionados)
                    {
                        Atividade atividade = new Atividade
                        {
                            idTipoAtividade = model.idTipoAtividade,
                            descricaoAtividade = model.descricaoAtividade,
                            idAluno = aluno,
                            dataEntrega = model.dataEntrega
                        };

                        context.Atividade.Add(atividade);
                    }
                    context.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                this.PreencherViewBags();
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // POST: Release/Createl(Cat


        // GET: Release/Edit/5
        public ActionResult Edit(int id)
        {
            using (AutismoContext context = new AutismoContext())
            {
                var db = context.Atividade.Find(id);

                AtividadeViewModel model = new AtividadeViewModel
                {
                    //id = db.id,
                    //nomeAtividade = db.nomeAtividade,
                    descricaoAtividade = db.descricaoAtividade,
                    //idAluno = db.idAluno,
                    dataEntrega = db.dataEntrega
                    //idTipoAtividade = db.idTipoAtividade
                };

                return View(model);
            }
        }

        // POST: Release/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, AtividadeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                using (AutismoContext context = new AutismoContext())
                {
                    var db = context.Atividade.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Atividade não encontrado!");
                        return View(model);
                    }
                    //db.nomeAtividade = model.nomeAtividade;
                    db.descricaoAtividade = model.descricaoAtividade;
                    //db.idAluno = model.idAluno;
                    db.dataEntrega = model.dataEntrega;
                    //db.idTipoAtividade = model.idTipoAtividade;

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
            using (AutismoContext context = new AutismoContext())
            {
                var db = context.Atividade.Find(id);

                AtividadeViewModel model = new AtividadeViewModel
                {
                    id = db.id,
                    nomeAtividade = db.nomeAtividade,
                    descricaoAtividade = db.descricaoAtividade,
                    idAluno = db.idAluno,
                    dataEntrega = db.dataEntrega,
                    idTipoAtividade = db.idTipoAtividade
                };

                return View(model);
            }
        }

        // POST: Release/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, AtividadeViewModel model)
        {
            try
            {
                using (AutismoContext context = new AutismoContext())
                {
                    var db = context.Atividade.Find(id);
                    if (db == null)
                    {
                        ModelState.AddModelError("", "Atividade não encontrada!");
                        return View(model);
                    }

                    context.Atividade.Remove(db);
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

        //    public ActionResult ListaAdocao(String Mensagem = "")
        //    {
        //        using (AutismoContext context = new AutismoContext())
        //        {
        //            var listDB = context.Atividade.OrderBy(x => x.id).ToList();
        //            var listViewModel = new List<AtividadeViewModel>();
        //            listDB.ForEach(x => listViewModel.Add(new AtividadeViewModel
        //            {
        //                id = x.id,
        //                nomeAtividade = x.nomeAtividade,
        //                descricaoAtividade = x.descricaoAtividade,
        //                aluno = x.aluno,
        //                dataEntrega = x.dataEntrega

        //            }));

        //            ViewBag.Mensagem = Mensagem;

        //            return View(listViewModel);
        //        }
        //    }


        //    public ActionResult Adotar(int id)
        //    {

        //        using (AutismoContext context = new AutismoContext())
        //        {
        //            var db = context.Atividade.Find(id);


        //            db.dataEntrega = DateTime.Now;


        //            context.Entry(db).State = EntityState.Modified;
        //            context.SaveChanges();
        //        }

        //        return RedirectToAction("ListaAtividade", new RouteValueDictionary(
        //new { controller = "Atividade", action = "ListaAtividade", Mensagem = "Animal adotado com sucesso!" }));



        //    }
    }
}