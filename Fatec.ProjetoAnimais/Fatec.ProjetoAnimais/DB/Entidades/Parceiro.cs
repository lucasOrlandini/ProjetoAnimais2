using System;


namespace Fatec.ProjetoAnimais.DB.Entitidades
{
    public class Parceiro
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string motivosParceria { get; set; }
        public string cnpjCpf { get; set; }
       
    }
}