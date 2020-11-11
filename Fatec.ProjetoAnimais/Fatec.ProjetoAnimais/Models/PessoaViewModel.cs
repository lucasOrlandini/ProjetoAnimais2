using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.Models
{
    public class PessoaViewModel
    {
  
        public enum ePerfil
        {
            Admin = 1,
            Usuario = 2
        }

        public int id { get; set; }

        [Required]
        public string cpf { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string nome { get; set; }

        public string sobrenome { get; set; }
        
        public DateTime? datanasc { get; set; }

        [Required]
        public string senha { get; set; }

        [Required]
        public int perfil { get; set; }


        public string descPerfil
        {
            get 
            {
                if(this.perfil == 1)
                {
                    return "Admin";
                }
                else
                {
                    return "Usuário";
                }
            }
        
        }

    }
}
