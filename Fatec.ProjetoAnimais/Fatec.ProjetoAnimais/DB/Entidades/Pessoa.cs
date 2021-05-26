using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fatec.ProjetoAnimais.DB.Entitidades
{
    public class Pessoa
    {
        [Key]
        public int id { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime? datanasc { get; set; }
        public string senha { get; set; }


        public int perfil { get; set; }


        [ForeignKey("perfil")]
        public Perfil perfilObjeto { get; set; }


    }
}