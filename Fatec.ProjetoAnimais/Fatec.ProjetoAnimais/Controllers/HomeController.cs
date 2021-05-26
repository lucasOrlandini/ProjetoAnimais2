using DotNet.Highcharts;
using DotNet.Highcharts.Enums;
using DotNet.Highcharts.Helpers;
using DotNet.Highcharts.Options;
using Fatec.ProjetoAnimais.DB.Contexto;
using Fatec.ProjetoAnimais.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fatec.ProjetoAnimais.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult IndexAdmin()
        {
            int quantidadeConcluidas = 0;
            int quantidadeNaoConcluidas = 0;

            int totalAtividades = 0;
            int totalCorretas = 0;
            int totalIncorretas = 0;
            int totalNaoFinalizada = 0;

            using (AutismoContext context = new AutismoContext())
            {
                quantidadeConcluidas = context.Atividade.Count(x => x.dataConclusao != null);
                quantidadeNaoConcluidas = context.Atividade.Count(x => x.dataConclusao == null);

                totalAtividades = context.Atividade.Count();
                totalCorretas = context.Atividade.Count(x => x.resultadoAtividade == 1);
                totalIncorretas = context.Atividade.Count(x => x.resultadoAtividade == 0);
                totalNaoFinalizada = context.Atividade.Count(x => x.resultadoAtividade == null);

            }

            
                


                IndexAdminViewModel viewModel = new IndexAdminViewModel();

            viewModel.grafico1 = new Highcharts("columnchart");
            viewModel.grafico1.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Pie,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.AliceBlue),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 2
            });
            viewModel.grafico1.SetTitle(new Title()
            {
                Text = "Status Atividade"
            });

            viewModel.grafico1.SetSeries(
                    new Series
                    {
                        Name = "Quantidade",
                        //ShowInLegend = true,
                        Data = new Data(new object[]
                        {
                            new object[] {"Concluídas", quantidadeConcluidas},
                            new object[] {"Pendentes", quantidadeNaoConcluidas},
                        })
                    }
                    );

            viewModel.grafico2 = new Highcharts("columnchart2");
            viewModel.grafico2.InitChart(new Chart()
            {
                Type = DotNet.Highcharts.Enums.ChartTypes.Pie,
                BackgroundColor = new BackColorOrGradient(System.Drawing.Color.AliceBlue),
                Style = "fontWeight: 'bold', fontSize: '17px'",
                BorderColor = System.Drawing.Color.LightBlue,
                BorderRadius = 0,
                BorderWidth = 2
            });
            viewModel.grafico2.SetTitle(new Title()
            {
                Text = "Percentual acertos"
            });

            viewModel.grafico2.SetSeries(
                    new Series
                    {
                        Name = "Percentual",
                        //ShowInLegend = true,
                        Data = new Data(new object[]
                        {
                            new object[] { "Corretas", (totalCorretas * 100 / totalAtividades )},
                            new object[] { "Incorretas", (totalIncorretas * 100 / totalAtividades )},
                            new object[] { "Pendentes", (totalNaoFinalizada * 100 / totalAtividades )},
                        })
                    }
                    );
            viewModel.grafico2.SetPlotOptions(new PlotOptions
            {
                Series = new PlotOptionsSeries
                {
                    DataLabels = new PlotOptionsSeriesDataLabels
                    {
                        Enabled = true,
                        Format = "<b>{point.name}</b>: {point.percentage:.1f} %"
                    }
                }
            });

            return View(viewModel);

        }
        public ActionResult IndexUsuario()
        {
            return View();
        }
    }
}