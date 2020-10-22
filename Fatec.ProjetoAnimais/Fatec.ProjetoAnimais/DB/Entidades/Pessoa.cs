using System;

namespace Fatec.ProjetoAnimais.DB.Entitidades
{
    public class Pessoa
    {
        public int id { get; set; }
        public string cpf { get; set; }
        public string email { get; set; }
        public string nome { get; set; }
        public string sobrenome { get; set; }
        public DateTime? datanasc { get; set; }
        public string senha { get; set; }
        public int perfil { get; set; }
        public string cpf2{ get; set; }
        public string cpf3{ get; set; }

        public string cpf4{ get; set; }


    }
}