using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.DB.Entitidades
{
    public class TipoAtividade
    {

        [Key]
        public int id { get; set; }

        public string descricaoTipoAtividade { get; set; }
    }
}