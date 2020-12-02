using System;


namespace Fatec.ProjetoAnimais.DB.Entitidades
{
    public class Doacoes
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime? data { get; set; }
        public string produto { get; set; }
        public int quantidade { get; set; }
        public Double valor { get; set; }
       
       
    }
}