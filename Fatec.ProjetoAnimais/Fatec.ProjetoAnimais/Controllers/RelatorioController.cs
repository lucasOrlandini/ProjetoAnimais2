//using Fatec.ProjetoAnimais.DB.Contexto;
//using Fatec.ProjetoAnimais.DB.Entitidades;
//using Fatec.ProjetoAnimais.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web.Mvc;

//namespace Fatec.ProjetoAnimais.Controllers
//{
//    public class RelatorioController : Controller
//    {
//        // GET: Release
//        public ActionResult Index()
//        {
//            return View();
//        }

//        public ActionResult AnimaisIndiponiveis()
//        {
//            using (AutismoContext context = new AutismoContext())
//            {
//                var listDB = context.Animal.Where(x => x.situacao == (int)AnimalViewModel.eSituacaoAnimal.Indisponivel).OrderBy(x => x.especie).ToList();
//                var listViewModel = new List<AnimalViewModel>();
//                listDB.ForEach(x => listViewModel.Add(new AnimalViewModel
//                {
//                    id = x.id,
//                    cidade_encontrado = x.cidade_encontrado,
//                    condicoes = x.condicoes,
//                    especie = x.especie,
//                    porte = x.porte,
//                    raca = x.raca,
//                    sexo = x.sexo,
//                    vacinas = x.vacinas,
//                    situacao = x.situacao,
//                    Data_adocao = x.Data_adocao

//                }));

//                return View(listViewModel);
//            }
//        }

//        public ActionResult AnimaisDisponiveis()
//        {
//            using (AutismoContext context = new AutismoContext())
//            {
//                var listDB = context.Animal.Where(x => x.situacao == (int)AnimalViewModel.eSituacaoAnimal.Disponivel).OrderBy(x => x.especie).ToList();
//                var listViewModel = new List<AnimalViewModel>();
//                listDB.ForEach(x => listViewModel.Add(new AnimalViewModel
//                {
//                    id = x.id,
//                    cidade_encontrado = x.cidade_encontrado,
//                    condicoes = x.condicoes,
//                    especie = x.especie,
//                    porte = x.porte,
//                    raca = x.raca,
//                    sexo = x.sexo,
//                    vacinas = x.vacinas,
//                    situacao = x.situacao,
//                    Data_adocao = x.Data_adocao

//                }));

//                return View(listViewModel);
//            }
//        }

//        public ActionResult DoacoesRealizadas()
//        {
//            using (AutismoContext context = new AutismoContext())
//            {
//                var listDB = context.Doacoes.OrderBy(x => x.nome).ToList();


//                var listViewModel = new List<DoacoesViewModel>();
//                listDB.ForEach(x => listViewModel.Add(new DoacoesViewModel
//                {
//                    id = x.id,
//                    nome = x.nome,
//                    data = (DateTime)x.data,
//                    produto = x.produto,
//                    quantidade = x.quantidade,
//                    valor = x.valor


//                }));

//                return View(listViewModel);
//            }
//        }

//    }
//}