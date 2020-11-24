using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class ParceiroViewModel
    {
  
       

        public int id { get; set; }

        [Required]
        public string nome { get; set; }

        [Required]
        public string telefone { get; set; }

        [Required]
        public string email { get; set; }

        public string endereco { get; set; }
        
        public string motivosParceria { get; set; }

        [Required]
        public string cnpjCpf { get; set; }


    }
}
