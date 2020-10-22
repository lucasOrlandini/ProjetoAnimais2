using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class AnimalViewModel
    {
    
        public int id { get; set; }
        public string cidade_encontrado { get; set; }
        public string condicoes { get; set; }
        public string especie { get; set; }
        public string porte { get; set; }
        public string raca { get; set; }
        public string sexo { get; set; }
        public string vacinas { get; set; }
        public string situacao { get; set; }

    }
}
