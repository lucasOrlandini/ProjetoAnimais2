using System;
using System.ComponentModel.DataAnnotations;

namespace Fatec.ProjetoAnimais.DB.Entitidades
{
    public class Perfil
    {
        [Key]
        public int id { get; set; }

        public string descricao { get; set; }
    }
}