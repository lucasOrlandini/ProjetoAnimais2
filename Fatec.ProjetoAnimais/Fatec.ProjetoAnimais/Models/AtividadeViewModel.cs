using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class AtividadeViewModel
    {
        public int id { get; set; }

        public string nomeAtividade { get; set; }

        [Required]
        public string descricaoAtividade { get; set; }


        [Display(Name = "Data de Entrega")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]

        [Required]
        public DateTime? dataEntrega { get; set; }

        public int idTipoAtividade { get; set; }

        public TipoAtividadeViewModel tipoAtividade { get; set; }

        public int idAluno { get; set; }

        public PessoaViewModel aluno { get; set; }

        private List<int> alunosSelecionados;
        public List<int> AlunosSelecionados 
        {
            get
            {
                if (alunosSelecionados == null)
                    alunosSelecionados = new List<int>();

                return alunosSelecionados;
            }
            set
            {
                alunosSelecionados = value;
            }
        }

        public int? resultadoAtividade { get; set; }

        public DateTime? dataConclusao { get; set; }


        public string textoResultadoAtividade 
        { 
            get
            {
                if (this.resultadoAtividade.HasValue && this.resultadoAtividade == 1)
                {
                    return "Correta";
                }
                else
                {
                    return "Incorreta";
                }
            }
        }
    }
}
