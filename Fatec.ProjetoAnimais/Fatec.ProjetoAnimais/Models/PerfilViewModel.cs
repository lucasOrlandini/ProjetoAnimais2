using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class PerfilViewModel
    {
        public int id { get; set; }

        [Required]
        public string descricao { get; set; }
    }
}
