using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class DoacoesViewModel
    {
  
       

        public int id { get; set; }

        
        public string nome { get; set; }

        [Display(Name = "Data de Retorno")]

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]

        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime data { get; set; }

       
        public string produto { get; set; }

       
        public int quantidade { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double valor { get; set; }



    }
}
