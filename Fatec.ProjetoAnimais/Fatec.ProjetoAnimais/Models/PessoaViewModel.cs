using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class PessoaViewModel
    {
        public int id { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public System.DateTime datanasc { get; set; }
        public string senha { get; set; }
    }
}
