using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class DoacoesViewModel
    {
  
       

        public int id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public DateTime data { get; set; }

        [Required]
        public string produto { get; set; }

        [Required]
        public int quantidade { get; set; }

        [Required]
        public Double valor { get; set; }



    }
}
