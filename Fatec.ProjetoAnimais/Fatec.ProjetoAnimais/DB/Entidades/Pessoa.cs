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

        public int perfil2 { get; set; }
        public int perfil3 { get; set; }
        public int perfil4 { get; set; }

    }
}