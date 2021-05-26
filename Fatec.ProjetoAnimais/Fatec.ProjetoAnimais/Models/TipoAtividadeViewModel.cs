using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class TipoAtividadeViewModel
    {
        public int id { get; set; }

        [Required]
        public string descricaoTipoAtividade { get; set; }
    }
}
