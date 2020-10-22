namespace Fatec.ProjetoAnimais.DB.Entitidades
{
    public class Animal
    {
        public int id { get; set; }
        public string cidade_encontrado { get; set; }
        public string condicoes { get; set; }
        public string especie { get; set; }
        public string porte { get; set; }
        public string raca { get; set; }
        public int sexo { get; set; }
        public int vacinas { get; set; }
        public int situacao { get; set; }

    }
}