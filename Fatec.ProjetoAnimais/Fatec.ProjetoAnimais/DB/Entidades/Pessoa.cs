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
        public DateTime datanasc { get; set; }
        public string senha { get; set; }
    }
}