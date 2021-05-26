using Fatec.ProjetoAnimais.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fatec.ProjetoAnimais.DB.Entitidades
{
    public class Atividade
    {
        [Key]
        public int id { get; set; }

        public string nomeAtividade { get; set; }

        public string descricaoAtividade { get; set; }

        public DateTime? dataEntrega { get; set; }
        public int? resultadoAtividade { get; set; }

  
        public DateTime? dataConclusao { get; set; }


        #region - Relacionamentos -

        public int idTipoAtividade { get; set; }

        [ForeignKey("idTipoAtividade")]
        public TipoAtividade tipoAtividade { get; set; }

        public int idAluno { get; set; }

        [ForeignKey("idAluno")]
        public Pessoa aluno { get; set; }

        #endregion
    }
}